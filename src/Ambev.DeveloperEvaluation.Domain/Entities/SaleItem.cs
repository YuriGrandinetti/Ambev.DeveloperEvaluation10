using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : ISaleItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; } = 0;
        public int Quantidade { get; set; }= 0;
        public decimal PrecoUnitario { get; set; }= decimal.Zero;
        public decimal DescontoItem { get; set; }=decimal.Zero;
        public decimal ValorTotalItem { get; set; } = decimal.Zero;
        public bool Cancelado { get; set; }=false;
        public Guid SaleId { get; set; }

        //  Propriedade de navegação
        public Product Product { get; set; } = new Product();
       
      //  public required ISale Sale { get ; set; }
    }
}
