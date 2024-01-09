using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Sale;
using CleanArchitecture.Application.Sales.UpdateSale;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.UpdateSale
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, SaleDto>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSaleCommandHandler(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SaleDto> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var existingSale = await _repository.FindByIdAsync(request.SaleId, cancellationToken);

            if (existingSale == null)
            {
                throw new NotFoundException($"Sale with ID {request.SaleId} not found.");
            }

            existingSale.Sumtotal = request.UpdatedSumtotal;

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SaleDto>(existingSale);
        }
    }
}
