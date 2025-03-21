using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    using System;
    using Xunit;

    using global::Ambev.DeveloperEvaluation.Domain.Entities;

    namespace Ambev.DeveloperEvaluation.Unit
    {
        public class SaleItemTests
        {
            [Fact]
            public void Deve_Calcular_Total_Do_SaleItem_Corretamente()
            {
                // Arrange
                int quantity = 3;
                decimal price = 50.0m;
                var saleItem = new SaleItem(Guid.NewGuid(), 90, quantity, price);

                // Act
                var total = saleItem.CalcularTotal();

                // Assert
                Assert.Equal(quantity * price, total);
            }
        }
    }

}
