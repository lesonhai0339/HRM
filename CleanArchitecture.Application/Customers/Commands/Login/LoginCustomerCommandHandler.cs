using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Login
{
    public class LoginCustomerCommandHandler : IRequestHandler<LoginCustomerCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILoginService _loginService;
        public LoginCustomerCommandHandler(ICustomerRepository customerRepository, ILoginService loginService)
        {
            _customerRepository = customerRepository;
            _loginService = loginService;
        }
        public async Task<string> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByName(request.Name, request.Password);
            if (customer == null)
            {
                throw new NotFoundException("Customer Does Not Exist");
            }
            var token = _loginService.GenerateLoginToken(customer);
            return token;
        }
    }
}
