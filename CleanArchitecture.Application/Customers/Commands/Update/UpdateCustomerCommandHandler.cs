using AutoMapper;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Common.Enums;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CusTomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IEncryptionService _encryption;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,IEncryptionService encryption)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _encryption = encryption;
        }

        public async Task<CusTomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer =await _customerRepository.FindById(request.Id);
            if (customer == null)
            {
                throw new NotFoundException("Customer Does Not Exist");
            }
            customer.Address = request.Address ?? customer.Address;
            customer.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, BCrypt.Net.SaltRevision.Revision2) ?? customer.Password;
            customer.PhoneNumber = request.PhoneNumber ?? customer.PhoneNumber;
            customer.Role = request.Role;
            _customerRepository.Update(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return customer.MapToCustomerDto(_mapper);
        }
    }
}
