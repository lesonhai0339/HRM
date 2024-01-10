using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.DeleteVendors
{
    public class DeleteVendorCommand : IRequest<bool>
    {
        public DeleteVendorCommand(Guid id) 
        {
            this.Id = id;
        }
        public Guid Id { get; set; }
    }
}
