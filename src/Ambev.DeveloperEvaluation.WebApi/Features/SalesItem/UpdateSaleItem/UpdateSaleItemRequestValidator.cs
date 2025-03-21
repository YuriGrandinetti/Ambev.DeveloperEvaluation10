using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CreateSaleItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.UpdateSaleItem
{
    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemRequestValidator() 
        {
            RuleFor(saleItem => saleItem.ProductId)
                 .GreaterThan(0).WithMessage("O ID do produto deve ser maior que 0.");

            RuleFor(saleItem => saleItem.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que 0.");

            RuleFor(saleItem => saleItem.PrecoUnitario)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que 0.");

            RuleFor(saleItem => saleItem.DescontoItem)
                .GreaterThanOrEqualTo(0).WithMessage("O desconto do item não pode ser negativo.");

            RuleFor(saleItem => saleItem.ValorTotalItem)
                .GreaterThanOrEqualTo(0).WithMessage("O valor total do item não pode ser negativo.");

            RuleFor(saleItem => saleItem.SaleId)
                .NotEmpty().WithMessage("O ID da venda não pode estar vazio.");
        } 
    }
}
