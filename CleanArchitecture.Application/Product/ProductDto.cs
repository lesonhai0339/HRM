using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Product
{
    public class ProductDto : IMapFrom<Domain.Entities.Product>
    {
        public ProductDto()
        {

        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CustumerId { get; set; }
        public Guid ShopId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Product, ProductDto>();
        }

    }
}
