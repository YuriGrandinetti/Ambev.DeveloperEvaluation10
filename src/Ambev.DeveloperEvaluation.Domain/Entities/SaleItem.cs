using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : ISaleItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; } = 0;
        public int Quantidade { get; set; }= 0;
        public decimal PrecoUnitario { get; set; }= decimal.Zero;
        public decimal DescontoItem { get; set; }=decimal.Zero;
        public decimal ValorTotalItem { get; set; } = decimal.Zero;
        public bool Cancelado { get; set; }=false;
        public Guid SaleId { get; set; }

        //  Propriedade de navegação
        public Product Product { get; set; } = new Product();

        /// <summary>
        /// Construtor customizado para criação de SaleItem.
        /// </summary>
        /// <param name="saleId">Identificador da venda associada.</param>
        /// <param name="productName">Nome do produto.</param>
        /// <param name="quantidade">Quantidade do produto.</param>
        /// <param name="precoUnitario">Preço unitário do produto.</param>
        public SaleItem(Guid saleId, int ProductId, int quantidade, decimal precoUnitario)
        {
            SaleId = saleId;
            this.ProductId = ProductId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            DescontoItem = 0m;
            ValorTotalItem = 0m;
            Cancelado = false;

        }

        public SaleItem()
        {
        }

        public decimal CalcularTotal()
        {
            // Se o item estiver cancelado, retorna 0.
            if (Cancelado)
            {
                return 0m;
            }

            // Calcula o total como a multiplicação do preço unitário pela quantidade,
            // subtraindo o desconto aplicado ao item.
            decimal total = (PrecoUnitario * Quantidade) - DescontoItem;

            // Atualiza a propriedade ValorTotalItem, se desejado.
            ValorTotalItem = total;

            return total;
        }

        //  public required ISale Sale { get ; set; }
    }
}
