using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.UpdateVendor
{
    public class UpdateVendorCommand : IRequest<VendorDTO>, ICommand
    {

        public UpdateVendorCommand(Guid id, string Name) 
        {
            Id = id;
            NameUpdated = Name;
        }
        public Guid Id { get; set; }
        public string NameUpdated { get; set; }
    }
}
