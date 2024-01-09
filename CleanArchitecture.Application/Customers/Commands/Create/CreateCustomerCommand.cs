using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Create
{
    public class CreateCustomerCommand: IRequest<CusTomerDto>, ICommand
    {
        public CreateCustomerCommand(string Name, string PhoneNumber, string Address, string Password)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address; 
            this.Password = Password;
        }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
