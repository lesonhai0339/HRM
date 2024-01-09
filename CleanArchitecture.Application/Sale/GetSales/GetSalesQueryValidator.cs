using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Sales.GetSales
{
    public class GetSalesQueryValidator : AbstractValidator<GetSalesQuery>
    {
        public GetSalesQueryValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
