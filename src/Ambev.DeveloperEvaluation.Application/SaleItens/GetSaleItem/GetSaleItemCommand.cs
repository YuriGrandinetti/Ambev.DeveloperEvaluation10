using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Security;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.GetSaleItem
{
    public class GetSaleItemCommand : IRequest<GetSaleItemResult>
    {
        public GetSaleItemCommand(int id)
        {
            Id = id;
        }
        /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public int Id { get; }
       
    }
}
