using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSalerValidator : AbstractValidator<DeleteSaleCommand>
    {
        public DeleteSalerValidator() 
        {

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User ID is required");
        }
    }
}
