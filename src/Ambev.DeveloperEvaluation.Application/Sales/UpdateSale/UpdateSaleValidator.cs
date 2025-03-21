using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Valida os dados do comando de atualização de venda.
    /// </summary>
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Sale ID cannot be empty.");

            RuleFor(x => x.NumeroVenda)
                .NotEmpty().WithMessage("NumeroVenda cannot be empty.")
                .MaximumLength(50).WithMessage("NumeroVenda cannot exceed 50 characters.");

            RuleFor(x => x.DataVenda)
                .NotEmpty().WithMessage("DataVenda cannot be empty.");

            RuleFor(x => x.ValorTotalVenda)
                .GreaterThanOrEqualTo(0).WithMessage("ValorTotalVenda cannot be negative.");
        }
    }
}

