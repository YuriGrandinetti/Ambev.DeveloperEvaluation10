using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public List<SaleItem> Itens { get; set; } = new List<SaleItem>();

        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }



    // public class CreateSaleItemDto
    // {
    //     public int ProductId { get; set; }
    //     public int Quantidade { get; set; }
    //     public decimal PrecoUnitario { get; set; }
    //     public decimal DescontoItem { get; set; }
    //     public decimal ValorTotalItem { get; set; }
    //     public bool Cancelado { get; set; }
    //     public Guid SaleId { get; set; }

    ////     public required ISale Sale { get; set; }

    // }

}

