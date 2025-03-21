using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    using System;
    using Bogus;
 
    using global::Ambev.DeveloperEvaluation.Domain.Entities;

    namespace Ambev.DeveloperEvaluation.Unit.TestData
    {
        public static class SaleItemTestData
        {
            private static readonly Faker faker = new Faker("pt_BR");

            public static SaleItem GetValidSaleItem()
            {
                return new SaleItem(
                    Guid.NewGuid(),
                    100,
                    faker.Random.Int(1, 10),
                    faker.Finance.Amount(10, 100)
                );
            }
        }
    }

}
