using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleValidator : AbstractValidator<GetSaleCommand>
    {
        public GetSaleValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
        }
    }
}
