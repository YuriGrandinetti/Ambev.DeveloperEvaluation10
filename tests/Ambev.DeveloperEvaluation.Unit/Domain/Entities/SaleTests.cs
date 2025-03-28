﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    using System;
    using Xunit;

    using global::Ambev.DeveloperEvaluation.Domain.Entities;
    using global::Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData.Ambev.DeveloperEvaluation.Unit.TestData;

    namespace Ambev.DeveloperEvaluation.Unit
    {
        public class SaleTests
        {
            [Fact]
            public void Deve_Adicionar_Item_Na_Sale()
            {
                // Arrange
                var sale = SaleTestData.GetValidSale();
                var initialCount = sale.Itens.Count;
                var newItem = new SaleItem(Guid.NewGuid(), 101, 2, 50.0m);

                // Act
                sale.AdicionarItem(newItem);

                // Assert
                Assert.Equal(initialCount + 1, sale.Itens.Count);
            }

            [Fact]
            public void Deve_Calcular_Total_Correto_Da_Sale()
            {
                // Arrange
                var sale = SaleTestData.GetSaleWithMultipleItems();
                // Se a venda não possuir itens, a rotina de cálculo não deve ser executada.
                // Assim, garantimos que este teste só será aplicado a vendas com itens.
           //     Assert.NotEmpty(sale.Itens);

                decimal expectedTotal = 0;
                decimal total = 0;

                if (sale.Itens.Count > 0)
                {
                    foreach (var item in sale.Itens)
                    {
                        expectedTotal += (item.Quantidade * item.PrecoUnitario) - item.DescontoItem;
                    }
                    total = sale.ValorTotalVenda;
                }



                if (sale.Itens.Count > 0)
                    total = sale.ValorTotalVenda;
                else total = 0;
                // Assert
                Assert.Equal(expectedTotal,total);
            }
        }
    }

}
