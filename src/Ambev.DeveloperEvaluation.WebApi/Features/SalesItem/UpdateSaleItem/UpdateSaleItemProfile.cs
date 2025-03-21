using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CreateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.UpdateSaleItem
{
    public class UpdateSaleItemProfile : Profile
    {
        public UpdateSaleItemProfile()
        {
            CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
            CreateMap<CreateSaleItemResult, CreateSaleItemResult>();
        }
    }
}
