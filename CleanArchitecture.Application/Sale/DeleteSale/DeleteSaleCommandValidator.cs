using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.DeleteSale
{
    public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
    {
        private readonly ISaleRepository _repository;

        public DeleteSaleCommandValidator(ISaleRepository repository)
        {
            _repository = repository;

            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.SaleId)
                .MustAsync(async (id, cancellationToken) => await _repository.FindByIdAsync(id, cancellationToken) != null)
                .WithMessage("There is no Sale with that id.");
        }
    }
}
