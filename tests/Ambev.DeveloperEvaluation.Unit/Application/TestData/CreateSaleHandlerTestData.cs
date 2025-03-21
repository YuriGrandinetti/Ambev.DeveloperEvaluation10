using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;



namespace Ambev.DeveloperEvaluation.Unit.TestData
    {
        public static class CreateSaleHandlerTestData
        {
            private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
             .RuleFor(u => u.DataVenda, f => f.Date.Recent())  // Gera uma data recente para a venda
             .RuleFor(u => u.NumeroVenda, f => $"Test@{f.Random.Number(1000, 9999)}"); // Gera um número aleatório entre 1000 e 9999

            public static CreateSaleCommand GenerateValidCommand()
            {
                return createSaleHandlerFaker.Generate();
            }
        }
}
