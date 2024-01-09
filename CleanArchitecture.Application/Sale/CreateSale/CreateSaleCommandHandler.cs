using AutoMapper;
using CleanArchitecture.Application.Sale;
using CleanArchitecture.Application.Sales.CreateSale;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, SaleDto>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _repository = saleRepository;
            _mapper = mapper;
        }

        public async Task<SaleDto> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new CleanArchitecture.Domain.Entities.Sale
            {
                Id = request.Id,
                Sumtotal = request.Sumtotal,
                CustomerId = request.CustomerId,
                VendorId = request.VendorId,
                ShopId = request.ShopId,
                ProductId = request.ProductId
            };

            _repository.Add(sale);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return sale.MapToSaleDto(_mapper);
        }
    }
}
