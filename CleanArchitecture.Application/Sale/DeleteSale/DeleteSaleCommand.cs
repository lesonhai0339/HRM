using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.DeleteSale
{
    public class DeleteSaleCommand : IRequest<Guid>, ICommand
    {
        public Guid SaleId { get; }

        public DeleteSaleCommand(Guid id)
        {
            SaleId = id;
        }
    }
}
