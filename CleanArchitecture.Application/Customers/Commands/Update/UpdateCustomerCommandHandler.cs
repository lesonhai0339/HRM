using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CusTomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CusTomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer =await _customerRepository.FindById(request.Id);
            if (customer == null)
            {
                throw new NotFoundException("Customer Does Not Exist");
            }
            customer = new Customer
            {
                Id = customer.Id,
                Name = request.Name,
                Address = request.Address,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
            };
            _customerRepository.Update(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return customer.MapToCustomerDto(_mapper);
        }
    }
}
