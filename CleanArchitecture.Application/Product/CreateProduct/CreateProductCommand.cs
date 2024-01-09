using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Application.Product.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>, ICommand
    {

        public CreateProductCommand(ProductDto dto)
        {
            Id = dto.ProductId;
            Name = dto.Name;
            Price = dto.Price;
            CustomerId = dto.CustumerId;
            ShopId = dto.ShopId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }
    }
}
