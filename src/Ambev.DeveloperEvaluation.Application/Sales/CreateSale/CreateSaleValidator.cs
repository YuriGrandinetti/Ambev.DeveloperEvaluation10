using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            // 1. A Data da venda não pode estar vazia
            // 2. A data da venda deve ser maior ou igual à data de hoje
            RuleFor(sale => sale.DataVenda)
                .NotEmpty().WithMessage("Data da venda não pode estar vazia.")
                .Must(data => data.Date >= DateTime.Today)
                .WithMessage("A data da venda deve ser maior ou igual à data de hoje.");

            // 3. O Cliente deve ser maior que 0
            RuleFor(sale => sale.CustomerId)
                .GreaterThan(0).WithMessage("O Cliente deve ser maior que 0.");

            // 4. A Filial deve ser maior que 0
            RuleFor(sale => sale.BranchId)
                .GreaterThan(0).WithMessage("A Filial deve ser maior que 0.");

            // 5. O Valor total da venda deve ser maior que 0
            RuleFor(sale => sale.ValorTotalVenda)
                .GreaterThan(0).WithMessage("O Valor total da venda deve ser maior que 0.");

            // 6. O número de itens deve ser maior que 0
            RuleFor(sale => sale.Itens)
                .NotEmpty().WithMessage("A venda deve conter pelo menos um item.");

            // Regras para cada item da venda
            RuleForEach(sale => sale.Itens).ChildRules(item =>
            {
                // 1. Id do item maior que 0
                item.RuleFor(i => i.Id)
                    .GreaterThan(0).WithMessage("O Id do item deve ser maior que 0.");

                // 2. ProductId maior que 0
                item.RuleFor(i => i.ProductId)
                    .GreaterThan(0).WithMessage("O ProductId deve ser maior que 0.");

                // 3. Quantidade maior que 0
                item.RuleFor(i => i.Quantidade)
                    .GreaterThan(0).WithMessage("A Quantidade deve ser maior que 0.");

                // 4. Preço unitário maior que 0
                item.RuleFor(i => i.PrecoUnitario)
                    .GreaterThan(0).WithMessage("O Preço unitário deve ser maior que 0.");

                // 5. Valor total do item maior que 0
                item.RuleFor(i => i.ValorTotalItem)
                    .GreaterThan(0).WithMessage("O Valor total do item deve ser maior que 0.");

                // 7. Cancelado é booleano e não necessita de validação explícita

                // 8. SaleId deve ser preenchido (para Guid, valida-se que não seja Guid.Empty)
                item.RuleFor(i => i.SaleId)
                    .NotEqual(Guid.Empty).WithMessage("O SaleId deve ser preenchido.");
            });

            // Regra para o número da venda
            RuleFor(sale => sale.NumeroVenda)
                .NotEmpty().WithMessage("Número da venda não pode estar em branco.");




        }
    }
}
