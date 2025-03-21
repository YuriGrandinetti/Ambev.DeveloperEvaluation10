using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.GetSaleItem
{
    public class GetSaleItemValidator : AbstractValidator<GetSaleItemCommand>
    {
        public GetSaleItemValidator() 
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage("User ID is required");
        }   
    }
}
