using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ICustomer
    {
        /// <summary>
        /// Obtém o identificador único do Cliente
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Obtém o Código do Cliente.
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Obtém o Nome do Cliente.
        /// </summary>
        public string Nome { get; set; }

    }
}
