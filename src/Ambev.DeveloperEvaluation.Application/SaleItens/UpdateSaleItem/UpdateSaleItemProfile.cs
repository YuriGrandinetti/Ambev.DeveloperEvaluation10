using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Mapeamento de UpdateSaleItemCommand para SaleItem e SaleItem para UpdateSaleItemResult.
    /// </summary>
    public class UpdateSaleItemProfile : Profile
    {
        public UpdateSaleItemProfile()
        {
            CreateMap<UpdateSaleItemCommand, SaleItem>();
            CreateMap<SaleItem, UpdateSaleItemResult>();
        }
    }
}

