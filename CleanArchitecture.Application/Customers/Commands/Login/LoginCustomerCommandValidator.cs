using AutoMapper;
using CleanArchitecture.Application.Customers.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Application.Customers.Commands.Login
{
    public class LoginCustomerCommandValidator: AbstractValidator<LoginCustomerCommand>
    {
       public LoginCustomerCommandValidator() 
       {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Required");
        }
    }
}
