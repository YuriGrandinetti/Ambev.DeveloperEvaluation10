using Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CreateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class CreateSaleItemRequestProfile : Profile
    {
        public CreateSaleItemRequestProfile()
        {
            CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        }
    }
}

