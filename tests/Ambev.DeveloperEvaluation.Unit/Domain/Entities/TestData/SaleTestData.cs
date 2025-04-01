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
              .RuleFor(u => u.DataVenda, f => f.Date.Between(DateTime.Today, DateTime.Today.AddDays(30)))// Gera uma data entre hoje e 30 dias a partir de hoje
             .RuleFor(u => u.NumeroVenda, f => $"Test@{f.Random.Number(1000, 9999)}"); // Gera um número aleatório entre 1000 e 9999


            public static Sale GetValidSale()
            {
                var saleFaker = new Faker<Sale>()
                    // Instancia a venda passando um novo Guid e uma data recente
                    .CustomInstantiator(f => new Sale(Guid.NewGuid(), f.Date.Recent()))
                     .RuleFor(u => u.DataVenda, f => f.Date.Between(DateTime.Today, DateTime.Today.AddDays(30))) // Gera uma data entre hoje e 30 dias a partir de hoje
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
                    .RuleFor(s => s.DataVenda, f => f.Date.Recent())
                    .RuleFor(s => s.CustomerId, f => f.Random.Int(1, 1000))
                    .RuleFor(s => s.BranchId, f => f.Random.Int(1, 1000))
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

            /// <summary>
            /// Gera um número de venda inválido (por exemplo, string vazia).
            /// </summary>
            public static string GenerateInvalidNumeroVenda()
            {
                // Retorna uma string vazia, o que é inválido se o campo não puder ser vazio.
                return new Faker().Random.String2(0);
            }

            /// <summary>
            /// Gera uma data de venda inválida (por exemplo, uma data no passado, se a regra exigir data >= hoje).
            /// </summary>
            public static DateTime GenerateInvalidDataVenda()
            {
                // Retorna uma data anterior a hoje.
                return DateTime.Today.AddDays(-new Faker().Random.Int(1, 30));
            }

            /// <summary>
            /// Gera um CustomerId inválido (por exemplo, 0 ou negativo).
            /// </summary>
            public static int GenerateInvalidCustomerId()
            {
                // Retorna zero, que pode ser inválido se a regra exigir um valor maior que 0.
                return 0;
            }

            /// <summary>
            /// Gera um BranchId inválido (por exemplo, 0 ou negativo).
            /// </summary>
            public static int GenerateInvalidBranchId()
            {
                // Retorna um número negativo.
                return -1;
            }

            /// <summary>
            /// Gera um ValorTotalVenda inválido (por exemplo, 0 ou negativo).
            /// </summary>
            public static decimal GenerateInvalidValorTotalVenda()
            {
                return 0m;
            }

            /// <summary>
            /// Gera uma lista de itens inválida.
            /// Pode ser considerada inválida se for nula ou vazia.
            /// </summary>
            public static List<SaleItem> GenerateInvalidItens()
            {
                // Exemplo: retorna uma lista vazia.
                return new List<SaleItem>();
                // Ou, alternativamente, retorne null:
                // return null;
            }

            // Métodos para gerar valores inválidos para os itens:

            /// <summary>
            /// Gera um ProductId inválido (por exemplo, 0 ou negativo).
            /// </summary>
            public static int GenerateInvalidProductId()
            {
                return 0;
            }

            /// <summary>
            /// Gera uma Quantidade inválida (por exemplo, 0).
            /// </summary>
            public static int GenerateInvalidQuantidade()
            {
                return 0;
            }

            /// <summary>
            /// Gera um PrecoUnitario inválido (por exemplo, 0 ou negativo).
            /// </summary>
            public static decimal GenerateInvalidPrecoUnitario()
            {
                return 0m;
            }

            /// <summary>
            /// Gera um DescontoItem inválido (por exemplo, um valor negativo, se a regra exigir somente valores não negativos).
            /// </summary>
            public static decimal GenerateInvalidDescontoItem()
            {
                return -1m;
            }

            /// <summary>
            /// Gera um ValorTotalItem inválido (por exemplo, 0 ou negativo).
            /// </summary>
            public static decimal GenerateInvalidValorTotalItem()
            {
                return 0m;
            }

            /// <summary>
            /// Gera um SaleId inválido (por exemplo, Guid.Empty).
            /// </summary>
            public static Guid GenerateInvalidSaleId()
            {
                return Guid.Empty;
            }
        }
    }

}
