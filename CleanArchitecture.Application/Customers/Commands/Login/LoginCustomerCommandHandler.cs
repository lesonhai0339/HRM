using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
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
        private readonly IEncryptionService _encryption;
        public LoginCustomerCommandHandler(ICustomerRepository customerRepository, ILoginService loginService, IEncryptionService encryption)
        {
            _customerRepository = customerRepository;
            _loginService = loginService;
            _encryption = encryption;
        }
        public async Task<string> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByName(request.Name);
            if (customer == null)
            {
                throw new NotFoundException("Customer Does Not Exist");
            }
            var checkpassword= _encryption.VerifyPassword(request.Password, customer.Password);
            if (!checkpassword) 
            {
                throw new NotFoundException("Wrong password");
            }
            var token = _loginService.GenerateLoginToken(customer);
            return token;
        }
    }
}
