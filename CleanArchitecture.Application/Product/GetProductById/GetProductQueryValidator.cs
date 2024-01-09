using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Product.GetProductById
{
    public class GetProductQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
            public GetProductQueryValidator() 
        {
            RuleFor(v => v.Id).NotNull();

        }
    }
}
