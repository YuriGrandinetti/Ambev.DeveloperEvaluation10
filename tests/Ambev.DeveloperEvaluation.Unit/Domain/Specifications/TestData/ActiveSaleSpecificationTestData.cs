using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData
{
    using System;
    using Bogus;
  
    using global::Ambev.DeveloperEvaluation.Domain.Entities;

    namespace Ambev.DeveloperEvaluation.Unit.TestData
    {
        public static class ActiveSaleSpecificationTestData
        {
            private static readonly Faker faker = new Faker("pt_BR");

            // Exemplo: uma venda é considerada ativa se possuir ao menos 1 item e a data for nos últimos 30 dias.
            public static Sale GetActiveSale()
            {
                var sale = new Sale(Guid.NewGuid(), DateTime.Now);
                sale.AdicionarItem(new SaleItem(Guid.NewGuid(), 10, faker.Random.Int(1, 10), faker.Finance.Amount(10, 100)));
                return sale;
            }

            public static Sale GetInactiveSale()
            {
                // Exemplo: venda inativa se a data for muito antiga ou sem itens
                var sale = new Sale(Guid.NewGuid(), DateTime.Now.AddDays(-40));
                // Pode ser testado também sem itens, se a regra for assim definida
                return sale;
            }
        }
    }

}
