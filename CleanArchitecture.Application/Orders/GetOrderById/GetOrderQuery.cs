using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetOrderById
{
    public class GetOrderQuery : IRequest<OrderDto>, IQuery
    {
        public GetOrderQuery(Guid Id) 
        {
            this.Id = Id;
        }
        public Guid Id { get; set; }
    }
}
