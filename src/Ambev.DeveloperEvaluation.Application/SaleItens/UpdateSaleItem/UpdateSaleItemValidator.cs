using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Valida os dados do comando de atualização de item de venda.
    /// </summary>
    public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemCommand>
    {
        public UpdateSaleItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("SaleItem ID must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("Quantidade cannot be negative.");

            RuleFor(x => x.PrecoUnitario)
                .GreaterThanOrEqualTo(0).WithMessage("PrecoUnitario cannot be negative.");

            RuleFor(x => x.DescontoItem)
                .GreaterThanOrEqualTo(0).WithMessage("DescontoItem cannot be negative.");

            RuleFor(x => x.ValorTotalItem)
                .GreaterThanOrEqualTo(0).WithMessage("ValorTotalItem cannot be negative.");
        }
    }
}

