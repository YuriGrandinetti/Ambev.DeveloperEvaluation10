using System;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Comando para atualizar uma venda existente.
    /// </summary>
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        /// <summary>
        /// Identificador único da venda.
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
        /// Identificador do cliente.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Identificador da filial.
        /// </summary>
        public int BranchId { get; set; }

        /// <summary>
        /// Valor total da venda.
        /// </summary>
        public decimal ValorTotalVenda { get; set; }
    }
}
