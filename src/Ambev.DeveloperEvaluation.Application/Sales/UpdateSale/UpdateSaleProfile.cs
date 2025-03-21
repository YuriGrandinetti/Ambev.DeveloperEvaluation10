using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Mapeamento de UpdateSaleCommand para Sale e Sale para UpdateSaleResult.
    /// </summary>
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>();
            CreateMap<Sale, UpdateSaleResult>();
        }
    }
}
