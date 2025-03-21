using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSAleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSAleRequestValidator()
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
