using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Login
{
    public class LoginCustomerCommand: IRequest<string>, ICommand
    {
        public LoginCustomerCommand(string name, string password)
        {
            this.Name= name;
            this.Password= password;
        }
        public string Name { get; set; }    
        public string Password { get; set; }    
    }
}
