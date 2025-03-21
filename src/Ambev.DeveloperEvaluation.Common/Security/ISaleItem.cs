using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISaleItem
    {
        /// <summary>
        ///  Obtém o identificador único do Item de Pedido
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Obtém o identificador único Produto Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Obtém a quantidade do produto no item
        /// </summary>
        public int Quantidade { get; set; }
        /// <summary>
        /// Obtém ao preço unitário do produto no item
        /// </summary>
        public decimal PrecoUnitario { get; set; }
        /// <summary>
        /// Obtém Dexconto  no item
        /// </summary>
        public decimal DescontoItem { get; set; }
        /// <summary>
        /// Obtém o Valor Total do item
        /// </summary>
        public decimal ValorTotalItem { get; set; }
        /// <summary>
        /// Obtém se o item foi cancelado
        /// </summary>
        public bool Cancelado { get; set; }

        /// <summary>
        /// Obtém ou define o identificador único da venda à qual o item pertence.
        /// </summary>
        Guid SaleId { get; set; }

        /// <summary>
        /// Obtém ou define a venda à qual o item pertence.
        /// </summary>
       // ISale Sale { get; set; }

    }
}
