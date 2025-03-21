using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Resultado retornado após a atualização de uma venda.
    /// </summary>
    public class UpdateSaleResult
    {
        /// <summary>
        /// Identificador único da venda atualizada.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Número da venda.
        /// </summary>
        public string NumeroVenda { get; set; }

        /// <summary>
        /// Data em que a venda foi realizada.
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Valor total da venda.
        /// </summary>
        public decimal ValorTotalVenda { get; set; }
    }
}
