using AutoMapper;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers
{
    public static class CustomerDtoMappingExtensions
    {
        public static CusTomerDto MapToCustomerDto(this Customer projectFrom, IMapper mapper)
            => mapper.Map<CusTomerDto>(projectFrom);

        public static List<CusTomerDto> MapToCustomerDtoList(this IEnumerable<Customer> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToCustomerDto(mapper)).ToList();
    }
}
