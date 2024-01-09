using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Sale
{
    public class SaleDto : IMapFrom<Domain.Entities.Sale>
    {
        public SaleDto() { }
        public Guid Id { get; set; }
        public decimal Sumtotal { get; set; }

        public Guid CustomerId { get; set; }
        public Guid VendorId { get; set; }
        public Guid ShopId { get; set; }
        public Guid ProductId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Sale, SaleDto>();
        }
    }
}
