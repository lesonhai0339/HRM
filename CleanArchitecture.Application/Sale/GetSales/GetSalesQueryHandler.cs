using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Sale;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.GetSales
{
    public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, List<SaleDto>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetSalesQueryHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<List<SaleDto>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.FindAllAsync(
                s => s.CustomerId == request.CustomerId,
                cancellationToken: cancellationToken
            );
            if (sales == null || !sales.Any())
                throw new NotFoundException($"Could not find any sales with name '{request.CustomerId}'");

            return sales.Select(sale => _mapper.Map<SaleDto>(sale)).ToList();
        }
    }
}
