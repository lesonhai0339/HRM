using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Querys.GetAll
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCusTomerQuery, List<CusTomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<CusTomerDto>> Handle(GetAllCusTomerQuery request, CancellationToken cancellationToken)
        {
            var listCustomer= await _customerRepository.FindAllAsync(cancellationToken);
            if(listCustomer == null || !listCustomer.Any()) 
            {
                throw new NotFoundException("Does Not Any Customer");
            }
            return listCustomer.MapToCustomerDtoList(_mapper);
        }
    }
}
