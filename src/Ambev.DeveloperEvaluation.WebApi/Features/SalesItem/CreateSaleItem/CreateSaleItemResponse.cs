namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CreateSaleItem
{
    public class CreateSaleItemResponse
    {
        /// <summary>
        /// O identificador único do item de venda criado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// O identificador do produto associado ao item de venda.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// A quantidade do produto no item de venda.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// O preço unitário do produto no item de venda.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// O desconto aplicado ao item de venda.
        /// </summary>
        public decimal DescontoItem { get; set; }

        /// <summary>
        /// O valor total do item de venda.
        /// </summary>
        public decimal ValorTotalItem { get; set; }

        /// <summary>
        /// O identificador da venda à qual este item pertence.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Indica se o item foi cancelado.
        /// </summary>
        public bool Cancelado { get; set; }
    }
}
