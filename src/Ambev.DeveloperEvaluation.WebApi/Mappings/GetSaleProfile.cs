using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.DTOs;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class GetSaleProfile : Profile
    {

        public GetSaleProfile() 
        {
            CreateMap<Sale, GetSaleItensResponse >()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.FilialId, opt => opt.MapFrom(src => src.BranchId))
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));

            CreateMap<SaleItem, GetSaleItemResponse>()
                .ForMember(dest => dest.ProdutoId, opt => opt.MapFrom(src => src.ProductId));

        }
    }
}
