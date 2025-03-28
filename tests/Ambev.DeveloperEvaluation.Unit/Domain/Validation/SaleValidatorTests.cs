using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    using System;
    using Xunit;

    using global::Ambev.DeveloperEvaluation.Domain.Entities;
    using global::Ambev.DeveloperEvaluation.Domain.Validation;
    using global::Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData.Ambev.DeveloperEvaluation.Unit.TestData;

    namespace Ambev.DeveloperEvaluation.Unit
    {
        public class SaleValidatorTests
        {
            private readonly SaleValidator validator;

            public SaleValidatorTests()
            {
                validator = new SaleValidator();
            }

            [Fact]
            public void Deve_Validar_Sale_Com_Dados_Validos()
            {
                // Arrange
                var sale = SaleTestData.GetValidSale();

                // Act
                var result = validator.Validate(sale);

                // Assert
                Assert.True(result.IsValid);
            }

            [Fact]
            public void Deve_Retornar_Erros_Para_Sale_Sem_Items()
            {
                // Arrange
                var sale = new Sale(Guid.NewGuid(), DateTime.Now)
                {
                    NumeroVenda = "Venda001", // Garante que o número da venda não está vazio
                    Itens = null            // Força a venda sem itens (valor nulo)
                };
                // Venda sem itens
               
                // Act
                var result = validator.Validate(sale);

                // Assert
                Assert.False(result.IsValid, "A venda sem itens deve ser considerada inválida.");
                // Assert.False(result.IsValid);
                Assert.Contains(result.Errors, error => error.PropertyName == "Itens");
            }
        }
    }

}
