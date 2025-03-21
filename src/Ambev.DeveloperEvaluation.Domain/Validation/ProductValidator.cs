using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(product => product.Codigo)
                 .NotEmpty()
                 .MinimumLength(3).WithMessage("Nome must be at least 3 characters long.")
                 .MaximumLength(50).WithMessage("Username cannot be longer than 50 characters.");

            RuleFor(product => product.Descricao)
                           .NotEmpty()
                           .MinimumLength(3).WithMessage("Codigo must be at least 3 characters long.")
                           .MaximumLength(50).WithMessage("Codigo cannot be longer than 50 characters.");

            RuleFor(product => product.PrecoUnitario)
            .GreaterThan(0).WithMessage("Preço unitário must be greater than 0.");

        }   
    }
}
