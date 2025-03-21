using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.GetSaleItem
{
    public class GetSaleItemProfile : Profile
    {
        public GetSaleItemProfile()
        {
            CreateMap<int, Application.SaleItens.GetSaleItem.GetSaleItemCommand>()
            .ConstructUsing(id => new Application.SaleItens.GetSaleItem.GetSaleItemCommand(id));
        }
    }
}
