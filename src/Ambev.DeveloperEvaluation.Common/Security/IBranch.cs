using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IBranch
    {
        /// <summary>
        /// Obtém o identificador único da Filial
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Obtém o Código da Filia.
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Obtém o Nome da Filial.
        /// </summary>
        public string Descricao { get; set; }
    }
}
