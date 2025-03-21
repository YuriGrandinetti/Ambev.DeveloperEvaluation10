using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem
{
    public class CreateSaleItemProfile : Profile
    {
        public CreateSaleItemProfile()             
        {
            CreateMap<CreateSaleItemCommand, SaleItem>();
            CreateMap<SaleItem, CreateSaleItemResult>();
        }
    }
}
