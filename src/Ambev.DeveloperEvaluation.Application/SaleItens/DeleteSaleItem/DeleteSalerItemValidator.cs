using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.DeleteSaleItem
{
    public class DeleteSalerItemValidator : AbstractValidator<DeleteSaleItemCommand>
    {
        public DeleteSalerItemValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Item ID is required");
        }
    }
}
