using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Sale;
using MediatR;
using System;

namespace CleanArchitecture.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<SaleDto>, ICommand
    {
        public CreateSaleCommand(Guid id, decimal sumtotal, Guid customerId, Guid vendorId, Guid shopId, Guid productId)
        {
            Id = id;
            Sumtotal = sumtotal;
            CustomerId = customerId;
            VendorId = vendorId;
            ShopId = shopId;
            ProductId = productId;
        }

        public Guid Id { get; set; }
        public decimal Sumtotal { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VendorId { get; set; }
        public Guid ShopId { get; set; }
        public Guid ProductId { get; set; }
    }
}
