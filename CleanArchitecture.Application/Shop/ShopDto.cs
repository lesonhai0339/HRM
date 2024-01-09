using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops
{
    public class ShopDto : IMapFrom<Shop>
    {
        public ShopDto() { }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = string.Empty;

        //public ICollection<Product> Products { get; set; } = new List<Product>();
        //public ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public static ShopDto createShop(Guid id, string name, string address, string phoneNumber) 
        {
            return new ShopDto()
            {
                Id = id,
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                //Products = new List<Product>(),
                //Sales = new List<Sale>()
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Shop, ShopDto>();
        //         .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
        //         .ForMember(dest => dest.Sales, opt => opt.MapFrom(src => src.Sales)); ;
        }
    }
}
