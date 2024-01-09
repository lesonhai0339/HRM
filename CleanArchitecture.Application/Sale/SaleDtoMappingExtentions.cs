using AutoMapper;
using CleanArchitecture.Application.Sale;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.Sale
{
    public static class SaleDtoMappingExtensions
    {
        public static SaleDto MapToSaleDto(this Domain.Entities.Sale saleFrom, IMapper mapper)
            => mapper.Map<SaleDto>(saleFrom);

        public static List<SaleDto> MapToSaleDtoList(this IEnumerable<Domain.Entities.Sale> salesFrom, IMapper mapper)
            => salesFrom.Select(x => x.MapToSaleDto(mapper)).ToList();
    }
}
