using AutoMapper;
using CleanArchitecture.Application.Customers;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops
{
    public static class ShopDtoMappingExtensions
    {
        public static ShopDto MapToShopDto(this Shop projectFrom, IMapper mapper)
           => mapper.Map<ShopDto>(projectFrom);

        public static List<ShopDto> MapToCustomerDtoList(this IEnumerable<Shop> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToShopDto(mapper)).ToList();
    }
}
