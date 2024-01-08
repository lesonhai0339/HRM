using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Product.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>,IQuery
    {
        public GetProductByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
        public Guid Id { get; set; }
    }
}
