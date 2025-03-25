using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common
{
    /// <summary>
    /// Representa um resultado paginado.
    /// </summary>
    public class PagedResult<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public List<T> Data { get; set; }
    }
}
