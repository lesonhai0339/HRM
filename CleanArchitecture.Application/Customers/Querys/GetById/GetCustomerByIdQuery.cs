using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Querys.GetById
{
    public class GetCustomerByIdQuery: IRequest<CusTomerDto>, IQuery
    {
        public GetCustomerByIdQuery(Guid id) 
        {
            this.Id = id;
        }
        public Guid Id { get;set; }
    }
}
