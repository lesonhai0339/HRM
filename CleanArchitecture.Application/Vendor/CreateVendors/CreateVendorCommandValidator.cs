using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.CreateVendors
{
    public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
    {
        private readonly IVendorRepository _repository;
        public CreateVendorCommandValidator(IVendorRepository repository) 
        {
            _repository = repository;

        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellationToken) => await _repository.FindByIdAsync(id,cancellationToken) == null)
                .WithMessage("Vendor with the same id already exists.");
            RuleFor(x => x.name)
                .MinimumLength(15)
                .MaximumLength(25)
                .WithMessage("The name must around 15 to 25 characters.");
        }
    }
}
