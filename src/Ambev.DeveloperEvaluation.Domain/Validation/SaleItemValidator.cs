using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(saleItem => saleItem.Quantidade)
           .GreaterThan(0)
           .WithMessage("A quantidade deve ser maior que 0.");

            RuleFor(saleItem => saleItem.PrecoUnitario)
                .GreaterThan(0)
                .WithMessage("O preço unitário deve ser maior que 0.");

        }
    }

    
}
