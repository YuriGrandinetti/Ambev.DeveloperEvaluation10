using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.DeleteSaleItem
{
    public  class DeleteSaleItemCommand : IRequest<DeleteSaleItemResponse>
    {
        public int Id { get; }
        public DeleteSaleItemCommand(int id) 
        {
            Id = id;
        }

    }
}
