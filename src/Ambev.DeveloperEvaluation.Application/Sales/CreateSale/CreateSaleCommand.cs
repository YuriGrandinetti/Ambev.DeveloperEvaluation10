﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public required string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public List<CreateSaleItemDto> Itens { get; set; }=new List<CreateSaleItemDto>();

    }
    public class CreateSaleItemDto
    {
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
