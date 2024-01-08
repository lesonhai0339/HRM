using CleanArchitecture.Domain.Common.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommand: IRequest<CusTomerDto>
    {
        public UpdateCustomerCommand(Guid id, string Name, string PhoneNumber, string Address, string Password)
        {
            this.Id = id;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.Password = Password;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
