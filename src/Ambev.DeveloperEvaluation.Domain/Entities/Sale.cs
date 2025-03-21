using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity, ISale
    {
        public Guid Id { get; set; }
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }= DateTime.MinValue;
        public int CustomerId { get; set; } = 0;
        public int BranchId { get; set; }= 0;
        public decimal ValorTotalVenda { get; set; } = decimal.Zero;

        // Propriedades de navegação
        public Customer Customer { get; set; } = new Customer();
        public Branch Branch { get; set; } = new Branch();
        public List<SaleItem> Itens { get; set; } = new List<SaleItem>();
        //ICustomer ISale.Customer { get; set ; }
        //IBranch ISale.Branch { get ; set ; }=new Branch();
        //IEnumerable<ISaleItem> ISale.Itens { get ; set ; }= Enumerable.Empty<ISaleItem>();
    }
}
