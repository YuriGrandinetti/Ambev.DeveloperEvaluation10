namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.UpdateSaleItem
{
    public class UpdateSaleItemRequest
    {


        /// <summary>
        /// Identificador do produto relacionado ao item de venda.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Quantidade do produto no item de venda.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário do produto.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Desconto aplicado ao item de venda.
        /// </summary>
        public decimal DescontoItem { get; set; }

        /// <summary>
        /// Valor total do item de venda.
        /// </summary>
        public decimal ValorTotalItem { get; set; }

        /// <summary>
        /// Identificador da venda à qual este item pertence.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Indica se o item de venda foi cancelado.
        /// </summary>
        public bool Cancelado { get; set; }
    }
}
