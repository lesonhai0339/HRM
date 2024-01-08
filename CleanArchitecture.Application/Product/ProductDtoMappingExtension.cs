using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Product;

namespace CleanArchitecture.Application.Product
{
    public static class ProductDtoMappingExtension
    {
        public static ProductDto MapToProductDto(this Domain.Entities.Product product, IMapper mapper)
        => mapper.Map<ProductDto>(product);
    }
}
