using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.GetVendors
{
    public class GetVendorCommandHandler : IRequestHandler<GetVendorCommand, List<VendorDTO>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        public GetVendorCommandHandler(IVendorRepository vendorRepository, IMapper mapper) 
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<List<VendorDTO>> Handle(GetVendorCommand request, CancellationToken cancellationToken)
        {
            var vendors = await _vendorRepository.FindAllAsync(x => x.Id.Equals(request.Id), cancellationToken: cancellationToken);
            if(vendors.Any() || vendors == null)
                throw new NotFoundException($"Could not find any vendors with name '{request.Id}'");
            return vendors.Select(x => _mapper.Map<VendorDTO>(x)).ToList();
        }
    }
}
