using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.GetSaleItem
{
    public class GetSaleItemProfile : Profile
    {
        public GetSaleItemProfile()
        {
            CreateMap<SaleItem, GetSaleItemResult>();
        }
    }
}
