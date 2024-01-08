using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Product.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>, IQuery
    {
        public GetProductsQuery(string? name)
        {
            this.Name = null;
        }


        public string? Name { get; set; }
    }
}
