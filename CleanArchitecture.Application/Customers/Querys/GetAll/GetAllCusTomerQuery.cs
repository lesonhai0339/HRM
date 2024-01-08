using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Querys.GetAll
{
    public class GetAllCusTomerQuery: IRequest<List<CusTomerDto>>, IQuery
    {
        public GetAllCusTomerQuery() { }
    }
}
