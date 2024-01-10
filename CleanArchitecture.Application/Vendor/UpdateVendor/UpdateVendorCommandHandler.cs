using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.UpdateVendor
{
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, VendorDTO>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        public UpdateVendorCommandHandler(IVendorRepository vendorRepository, IMapper mapper) 
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorDTO> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorRepository.FindByIdAsync(request.Id, cancellationToken);
            if (vendor == null)
                throw new ArgumentException($"Vendor with ID : {request.Id} is not found");
            vendor.Name = request.NameUpdated;
            _vendorRepository.Update(vendor);
            await _vendorRepository.UnitOfWork.SaveChangesAsync();
            return _mapper.Map<VendorDTO>(vendor);
        }
    }
}
