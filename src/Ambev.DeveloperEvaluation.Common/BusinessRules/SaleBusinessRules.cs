using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Exceptions;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Common.BusinessRules
{
    /// <summary>
    /// Contém as regras de negócio relacionadas à venda.
    /// </summary>
    public static class SaleBusinessRules
    {
        /// <summary>
        /// Calcula o desconto para um item de venda com base na quantidade e no valor total.
        /// </summary>
        /// <param name="quantidade">Quantidade do produto no item.</param>
        /// <param name="precoUnitario">Preço unitário do produto.</param>
        /// <param name="valorTotal">Valor total do item (quantidade * preço unitário).</param>
        /// <returns>O desconto calculado conforme as regras de negócio.</returns>
        public static decimal CalculateDiscount(int quantidade, decimal precoUnitario, decimal valorTotal)
        {
            // Se a quantidade estiver entre 10 e 20, aplica 20% de desconto;
            // Se a quantidade for maior ou igual a 4, aplica 10% de desconto;
            // Caso contrário, sem desconto.
            if (quantidade >= 10 && quantidade <= 20)
            {
                return valorTotal * 0.20m;
            }
            else if (quantidade >= 4)
            {
                return valorTotal * 0.10m;
            }
            return 0;
        }
        // <summary>
        /// Valida se a quantidade de cada item da venda não ultrapassa o limite permitido.
        /// </summary>
        /// <param name="saleItems">Coleção de itens da venda.</param>
        /// <exception cref="BusinessRuleException">
        /// Lançada se algum item possuir quantidade maior que 20.
        /// </exception>
        public static void ValidateSaleItemQuantity(IEnumerable<ISaleItem> saleItems)
        {
            foreach (var item in saleItems)
            {
                if (item.Quantidade > 20)
                {
                    throw new BusinessRuleException("Não é possível vender acima de 20 itens idênticos por produto.");
                }
            }
        }
    }
}
