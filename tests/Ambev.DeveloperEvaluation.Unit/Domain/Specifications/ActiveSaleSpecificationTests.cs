using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    using Xunit;
 
    using global::Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData.Ambev.DeveloperEvaluation.Unit.TestData;

    namespace Ambev.DeveloperEvaluation.Unit
    {
        public class ActiveSaleSpecificationTests
        {
            private readonly ActiveSaleSpecification spec;

            public ActiveSaleSpecificationTests()
            {
                spec = new ActiveSaleSpecification();
            }

            [Fact]
            public void Deve_Retornar_Verdadeiro_Para_Sale_Ativa()
            {
                // Arrange
                var sale = ActiveSaleSpecificationTestData.GetActiveSale();

                // Act
                var isActive = spec.IsSatisfiedBy(sale);

                // Assert
                Assert.True(isActive);
            }

            [Fact]
            public void Deve_Retornar_Falso_Para_Sale_Inativa()
            {
                // Arrange
                var sale = ActiveSaleSpecificationTestData.GetInactiveSale();

                // Act
                var isActive = spec.IsSatisfiedBy(sale);

                // Assert
                Assert.False(isActive);
            }
        }
    }

}
