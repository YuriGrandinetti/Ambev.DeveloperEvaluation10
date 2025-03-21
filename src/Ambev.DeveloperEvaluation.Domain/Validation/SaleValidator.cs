using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.DataVenda)
         .NotEmpty().WithMessage("Data da venda não pode estar vazia.")
         .Must(data => data.Date >= DateTime.Today)
         .WithMessage("A data da venda deve ser maior ou igual à data de hoje.");

            RuleFor(sale => sale.NumeroVenda)
                 .NotEmpty().WithMessage("Número da venda não pode estar em branco.");

        }
    }
}
