using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Querys.GetAll
{
    public class GetAllShopQuery : IRequest<List<ShopDto>>,IQuery
    {
        public GetAllShopQuery() { }
    }
}
