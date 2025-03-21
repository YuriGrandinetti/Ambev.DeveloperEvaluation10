using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISale
    {
        /// <summary>
        /// Obtém o identificador único do Pedido
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Obtém o Número de Pedido
        /// </summary>
        public string NumeroVenda { get; set; }
        /// <summary>
        /// Obtém a Data do pedido
        /// </summary>
        public DateTime DataVenda { get; set; }
        /// <summary>
        /// Obtém o Identificador unico do Cliente do Pedido
        /// </summary>
        public int CustomerId { get; set;  }
        /// <summary>
        /// Obtém o Identificador unico da Filial
        /// </summary>
        public int BranchId { get; set; }
        /// <summary>
        /// Obtém o Valor Total de Venda do Pedido
        /// </summary>
        public decimal ValorTotalVenda { get; set; }
        // Propriedade de navegação para o produto relacionado
        // Propriedades de navegação utilizando as interfaces das entidades relacionadas
        //ICustomer Customer { get; set; }
        //IBranch Branch { get; set; }
        //IEnumerable<ISaleItem> Itens { get; set; }
    }
}
