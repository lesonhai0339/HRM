using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Querys.GetById
{
    public class GetShopByIdQuery: IRequest<ShopDto>,IQuery
    {

        public GetShopByIdQuery(Guid id) 
        { 
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
