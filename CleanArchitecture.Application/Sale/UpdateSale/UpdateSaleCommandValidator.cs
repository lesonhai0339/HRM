using FluentValidation;

namespace CleanArchitecture.Application.Sales.UpdateSale
{
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleCommandValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty().WithMessage("SaleId must not be empty.");

            RuleFor(x => x.UpdatedSumtotal).GreaterThan(0).WithMessage("UpdatedSumtotal must be greater than 0.");
        }
    }
}
