using CleanArchitecture.Application.Sale;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Sales.GetSales
{
    public class GetSalesQuery : IRequest<List<SaleDto>>
    {
        public Guid CustomerId { get; set; }

        public GetSalesQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
