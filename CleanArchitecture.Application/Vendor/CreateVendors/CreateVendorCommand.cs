using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.CreateVendors
{
    public class CreateVendorCommand : IRequest<VendorDTO>, ICommand
    {
        public CreateVendorCommand(Guid id, string name) 
        {
            this.Id = id;
            this.name = name;
        }
        public Guid Id { get; set; }
        public string name { get; set; }
    }
}
