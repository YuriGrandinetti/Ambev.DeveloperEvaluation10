using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.DTOs
{
    /// <summary>
    /// Representa os dados de uma venda com seus itens.
    /// </summary>
    public class GetSaleItemResponse
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal DescontoItem { get; set; }
        public decimal ValorTotalItem { get; set; }
        public bool Cancelado { get; set; }
    }
}
