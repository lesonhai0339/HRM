using CleanArchitecture.Application.Sales.CreateSale;
using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        private readonly ISaleRepository _repository;

        public CreateSaleCommandValidator(ISaleRepository repository)
        {
            _repository = repository;

            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellationToken) => await _repository.FindByIdAsync(id, cancellationToken) == null)
                .WithMessage("Sale with the same Id already exists.");

            RuleFor(x => x.Sumtotal)
                .GreaterThan(0).WithMessage("Sumtotal must be greater than 0.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId must not be empty.");

            RuleFor(x => x.VendorId)
                .NotEmpty().WithMessage("VendorId must not be empty.");

            RuleFor(x => x.ShopId)
                .NotEmpty().WithMessage("ShopId must not be empty.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId must not be empty.");
        }
    }
}
