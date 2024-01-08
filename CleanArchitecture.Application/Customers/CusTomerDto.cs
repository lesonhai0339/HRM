using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common.Enums;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers
{
    public class CusTomerDto : IMapFrom<Customer>
    {
        public CusTomerDto()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; } = null!;
        public Role Role { get; set; }

        public static CusTomerDto Create(Guid id, string name, string phonenumber, string address, string password, Role role)
        {
            return new CusTomerDto
            {
                Id = id,
                Name = name,
                PhoneNumber= phonenumber ?? "",
                Address = address ?? "",
                Password = password,
                Role= role
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CusTomerDto>();
        }
    }
}
