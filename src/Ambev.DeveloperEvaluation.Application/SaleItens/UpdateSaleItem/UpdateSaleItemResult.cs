namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Resultado retornado após a atualização de um item de venda.
    /// </summary>
    public class UpdateSaleItemResult
    {
        /// <summary>
        /// Identificador único do item de venda atualizado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Quantidade do produto no item.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário do produto no item.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Desconto aplicado ao item.
        /// </summary>
        public decimal DescontoItem { get; set; }

        /// <summary>
        /// Valor total do item.
        /// </summary>
        public decimal ValorTotalItem { get; set; }

        /// <summary>
        /// Indica se o item está cancelado.
        /// </summary>
        public bool Cancelado { get; set; }
    }
}

