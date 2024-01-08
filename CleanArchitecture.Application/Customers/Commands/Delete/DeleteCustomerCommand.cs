using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommand: IRequest<bool>
    {
        public DeleteCustomerCommand(Guid id) 
        {
            this.Id = id;
        }
        public Guid Id { get;set; }
    }
}
