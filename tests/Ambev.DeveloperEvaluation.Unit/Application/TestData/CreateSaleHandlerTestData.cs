using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;



namespace Ambev.DeveloperEvaluation.Unit.TestData
    {
        public static class CreateSaleHandlerTestData
        {
       // var saleFaker = new Faker<Sale>()

        private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
             //.RuleFor(u => u.DataVenda, f => f.Date.Recent())  // Gera uma data recente para a venda
             //.RuleFor(u => u.NumeroVenda, f => $"Test@{f.Random.Number(1000, 9999)}"); // Gera um número aleatório entre 1000 e 9999
             // .RuleFor(s => s.Id, f => f.Random.Guid())
             .RuleFor(s => s.NumeroVenda, f => f.Commerce.ProductName())
             .RuleFor(s => s.DataVenda, f => f.Date.Recent())
             .RuleFor(s => s.CustomerId, f => f.Random.Int(1, 1000))
             .RuleFor(s => s.BranchId, f => f.Random.Int(1, 1000))
             .RuleFor(s => s.ValorTotalVenda, f => f.Finance.Amount(100, 1000))
             .RuleFor(s => s.Itens, f => new Faker<SaleItem>()
             .RuleFor(si => si.Id, f => f.Random.Int(1, 10000))
             .RuleFor(si => si.ProductId, f => f.Random.Int(1, 10000))
             .RuleFor(si => si.PrecoUnitario, f => f.Finance.Amount(10, 100))
             .RuleFor(si => si.DescontoItem, f => f.Finance.Amount(0, 10))
             .RuleFor(si => si.Quantidade, f => f.Random.Int(1, 10))
             .RuleFor(si => si.SaleId, f => f.Random.Guid())
             .RuleFor(si => si.Cancelado, f => false)
            // Opcional: calcula o ValorTotalItem com base nas regras do domínio
            //.RuleFor(si => si.ValorTotalItem, (f, si) => (si.PrecoUnitario * si.Quantidade) - si.DescontoItem)
             .Generate(3)
        );
        public static CreateSaleCommand GenerateValidCommand()
            {
                return createSaleHandlerFaker.Generate();
            }
        }
}
