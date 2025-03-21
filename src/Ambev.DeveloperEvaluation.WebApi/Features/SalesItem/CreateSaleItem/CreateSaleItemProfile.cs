using Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CreateSaleItem
{
    public class CreateSaleItemProfile : Profile
    {
        public CreateSaleItemProfile() 
        {
            CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
            CreateMap<CreateSaleItemResult, CreateSaleItemResult>();
        }  
    }
}
