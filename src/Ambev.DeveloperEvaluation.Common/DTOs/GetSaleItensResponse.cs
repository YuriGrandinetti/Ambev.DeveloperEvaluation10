using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.DTOs
{
    /// <summary>
    /// Representa os dados de um item de venda.
    /// </summary>
    public class GetSaleItensResponse
    {
        public Guid Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public int FilialId { get; set; }
        public List<GetSaleItemResponse> Itens { get; set; } = new List<GetSaleItemResponse>();
        public int Total { get; set; }

    }
}
