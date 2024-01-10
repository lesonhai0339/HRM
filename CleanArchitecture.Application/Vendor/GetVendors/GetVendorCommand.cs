using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.GetVendors
{
    public class GetVendorCommand : IRequest<List<VendorDTO>>
    {
        public GetVendorCommand(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
