using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem
{
    public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemCommand>
    {
        public CreateSaleItemValidator() 
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("Quantidade must be greater than 0.");

            RuleFor(x => x.PrecoUnitario)
                .GreaterThan(0)
                .WithMessage("PrecoUnitario must be greater than 0.00.");

            RuleFor(x => x.DescontoItem)
                .GreaterThanOrEqualTo(0)
                .WithMessage("DescontoItem must be greater than or equal to 0.");

            //RuleFor(x => x.SaleId)
            //    .GreaterThan(0)
            //    .WithMessage("SaleId must be greater than 0.");
        }

    
    }
}
