using AutoMapper;
using BCrypt.Net;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CusTomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEncryptionService _encryption;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IEncryptionService encryption)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _encryption = encryption;
        }
        public async Task<CusTomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByName(request.Name);
            if(customer != null)
            {
                throw new NotFoundException("Customer has exist");
            }
            var cus = new Customer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                Password = _encryption.EncryptPassword(request.Password),
                PhoneNumber = request.PhoneNumber,
                Role = Domain.Common.Enums.Role.Customer,
            };
            _customerRepository.Add(cus);
            await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return cus.MapToCustomerDto(_mapper);
        }
    }
}
