using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created user
        /// </summary>
        public Guid Id { get; set; }
        public required string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public List<GetSaleItensResponse> Itens { get; set; } = new List<GetSaleItensResponse>();
    }
}
