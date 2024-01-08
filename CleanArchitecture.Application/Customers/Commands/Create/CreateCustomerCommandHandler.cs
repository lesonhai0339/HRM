using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
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
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CusTomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Role = Domain.Common.Enums.Role.Customer,
            };
            _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return customer.MapToCustomerDto(_mapper);
        }
    }
}
