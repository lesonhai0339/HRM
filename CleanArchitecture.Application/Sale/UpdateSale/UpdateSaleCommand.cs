using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Sale;
using MediatR;
using System;

namespace CleanArchitecture.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<SaleDto>, ICommand
    {
        public Guid SaleId { get; set; }
        public decimal UpdatedSumtotal { get; set; }

        public UpdateSaleCommand(Guid saleId, decimal updatedSumtotal)
        {
            SaleId = saleId;
            UpdatedSumtotal = updatedSumtotal;
        }
    }
}
