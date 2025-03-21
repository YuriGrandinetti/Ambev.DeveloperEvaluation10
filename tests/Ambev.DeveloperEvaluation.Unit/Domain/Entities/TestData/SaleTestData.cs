using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    using System;
    using System.Collections.Generic;
    using Bogus;
 
    using global::Ambev.DeveloperEvaluation.Domain.Entities;
    using global::Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

    namespace Ambev.DeveloperEvaluation.Unit.TestData
    {
        public static class SaleTestData
        {
            private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
             .RuleFor(u => u.DataVenda, f => f.Date.Recent())  // Gera uma data recente para a venda
             .RuleFor(u => u.NumeroVenda, f => $"Test@{f.Random.Number(1000, 9999)}"); // Gera um número aleatório entre 1000 e 9999


            public static Sale GetValidSale()
            {
                var saleFaker = new Faker<Sale>()
                    // Instancia a venda passando um novo Guid e uma data recente
                    .CustomInstantiator(f => new Sale(Guid.NewGuid(), f.Date.Recent()))
                    // Configura a propriedade NumeroVenda com um número aleatório formatado
                    .RuleFor(s => s.NumeroVenda, f => $"Test@{f.Random.Number(1000, 9999)}")
                    // Adiciona um item à venda ao final da criação da instância
                    .FinishWith((f, sale) =>
                    {
                        sale.AdicionarItem(new SaleItem(
                            Guid.NewGuid(),
                            10,
                            f.Random.Int(1, 10),
                            (decimal)f.Finance.Amount(10, 100)
                        ));
                    });

                return saleFaker.Generate();
            }


            public static Sale GenerateValidUser()
            {
                return SaleFaker.Generate();
            }


            public static Sale GetSaleWithMultipleItems()
            {
                var saleFaker = new Faker<Sale>()
                    .CustomInstantiator(f => new Sale(Guid.NewGuid(), f.Date.Recent()))
                    .RuleFor(s => s.NumeroVenda, f => $"Test@{f.Random.Number(1000, 9999)}")
                    .FinishWith((f, sale) =>
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            sale.AdicionarItem(new SaleItem(
                                Guid.NewGuid(),
                                100,
                                f.Random.Int(1, 5),
                                (decimal)f.Finance.Amount(20, 200)
                            ));
                        }
                    });

                return saleFaker.Generate();
            }
        }
    }

}
