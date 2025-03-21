using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.DeleteSaleItem
{
    public class DeleteSaleItemProfile : Profile
    {
        public DeleteSaleItemProfile() 
        {
            CreateMap<int, Application.SaleItens.DeleteSaleItem.DeleteSaleItemCommand>()
            .ConstructUsing(id => new Application.SaleItens.DeleteSaleItem.DeleteSaleItemCommand(id));
        }
    }
}
