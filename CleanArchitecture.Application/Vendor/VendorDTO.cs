using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor
{
    public class VendorDTO : IMapFrom<Domain.Entities.Vendor>
    {
        public VendorDTO() { }
        public Guid id { get; set; }
        public string name { get; set; }
        public static VendorDTO Add(Guid id, string name)
        {
            return new VendorDTO() { 
                id = id, 
                name = name 
            };
        }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<Domain.Entities.Vendor,VendorDTO>();
        }
    }
}
