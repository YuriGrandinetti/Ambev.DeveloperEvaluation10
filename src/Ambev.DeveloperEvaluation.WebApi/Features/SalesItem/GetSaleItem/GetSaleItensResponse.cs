namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.GetSaleItem
{
    public class GetSaleItensResponse
    {
        public Guid Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public int FilialId { get; set; }
        public List<GetSaleItemResponse> Itens { get; set; } 
    }
}
