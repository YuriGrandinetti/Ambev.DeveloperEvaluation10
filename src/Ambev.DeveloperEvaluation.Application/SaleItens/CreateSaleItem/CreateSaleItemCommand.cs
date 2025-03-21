using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Security;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem
{
    public class CreateSaleItemCommand : IRequest<CreateSaleItemResult>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal DescontoItem { get; set; }
        public decimal ValorTotalItem { get; set; }
        public bool Cancelado { get; set; }
        public Guid SaleId { get; set; }

        public required ISale Sale { get; set; }

    }
}
