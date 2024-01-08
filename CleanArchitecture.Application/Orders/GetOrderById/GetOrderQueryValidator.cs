using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetOrderById
{
    public class GetOrderQueryValidator: AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(v => v.Id).NotNull();
        }
    }
}
