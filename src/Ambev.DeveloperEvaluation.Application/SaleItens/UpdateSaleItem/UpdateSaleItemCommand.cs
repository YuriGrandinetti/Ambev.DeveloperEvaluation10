using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Comando para atualizar um item de venda existente.
    /// </summary>
    public class UpdateSaleItemCommand : IRequest<UpdateSaleItemResult>
    {
        /// <summary>
        /// Identificador único do item de venda.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Quantidade do produto.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário do produto.
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
        /// Define se o item está cancelado.
        /// Definir como true para cancelar o item.
        /// </summary>
        public bool Cancelado { get; set; }
    }
}

