using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.DeleteVendors
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, bool>
    {
        private readonly IVendorRepository _vendorRepository;
        public DeleteVendorCommandHandler(IVendorRepository vendorRepository) 
        {
            _vendorRepository = vendorRepository;
        }
        public async Task<bool> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorRepository.FindByIdAsync(request.Id);
            if (vendor == null)
            {
                return false;
            }
            _vendorRepository.Remove(vendor);
            await _vendorRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
