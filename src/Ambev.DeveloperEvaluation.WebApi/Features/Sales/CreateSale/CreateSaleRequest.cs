using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public required string NumeroVenda { get; set; } 
        public DateTime DataVenda { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public List<CreateSaleItemDto> Itens { get; set; } = new List<CreateSaleItemDto>();
    }
}
