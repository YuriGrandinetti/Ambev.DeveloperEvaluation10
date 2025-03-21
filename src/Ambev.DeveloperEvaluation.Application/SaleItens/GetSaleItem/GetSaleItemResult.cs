using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.GetSaleItem
{
    public class GetSaleItemResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale item.
        /// </summary>
        /// <value>An integer representing the sale item identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        /// <value>An integer representing the product identifier.</value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale item.
        /// </summary>
        /// <value>An integer representing the quantity.</value>
        public int Quantidade { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product in the sale item.
        /// </summary>
        /// <value>A decimal representing the unit price.</value>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the sale item.
        /// </summary>
        /// <value>A decimal representing the discount value.</value>
        public decimal DescontoItem { get; set; }

        /// <summary>
        /// Gets or sets the total value of the sale item.
        /// </summary>
        /// <value>A decimal representing the total item value.</value>
        public decimal ValorTotalItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sale item is cancelled.
        /// </summary>
        /// <value>True if the sale item is cancelled; otherwise, false.</value>
        public bool Cancelado { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale to which this item belongs.
        /// </summary>
        /// <value>A GUID that uniquely identifies the related sale.</value>
        public Guid SaleId { get; set; }
    }
}
