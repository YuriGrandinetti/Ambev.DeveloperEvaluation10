
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public  class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() 
        {
           
            RuleFor(customer => customer.Nome)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Nome must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Username cannot be longer than 50 characters.");

            RuleFor(customer => customer.Codigo)
                           .NotEmpty()
                           .MinimumLength(3).WithMessage("Codigo must be at least 3 characters long.")
                           .MaximumLength(50).WithMessage("Codigo cannot be longer than 50 characters.");

        }   
    }
}
