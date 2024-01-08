using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Querys.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CusTomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CusTomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindById(request.Id);
            if(customer == null)
            {
                throw new NotFoundException("Customer Does Not Exits");
            }
            return customer.MapToCustomerDto(_mapper);
        }
    }
}
