using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IProduct
    {
        /// <summary>
        /// Obtém o identificador único do Produto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Obtém o Código do Preoduto
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Obtém a Descrição do Preoduto
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Obtém o Preço Unitário do Preoduto
        /// </summary>
        public decimal PrecoUnitario { get; set; }

    }
}
