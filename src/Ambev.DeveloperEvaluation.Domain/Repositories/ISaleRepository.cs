using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common;
using Ambev.DeveloperEvaluation.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Sale>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Sale sale, CancellationToken cancellationToken = default);
        Task UpdateAsync(Sale sale);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        //    Task<IEnumerable<GetSaleItensResponse>> GetSalesWithProjectionAsync(
        //DateTime dataInicial,
        //DateTime dataFinal,
        //CancellationToken cancellationToken = default);
        /// <summary>
        /// Recupera uma lista paginada de vendas com seus itens, filtrando pelo período e aplicando ordenação.
        /// </summary>
        /// <param name="dataInicial">Data inicial para o filtro (obrigatória).</param>
        /// <param name="dataFinal">Data final para o filtro (obrigatória).</param>
        /// <param name="page">Número da página (default: 1).</param>
        /// <param name="size">Número de itens por página (default: 10).</param>
        /// <param name="order">Critério de ordenação (default: "dataVenda asc").</param>
        /// <param name="cancellationToken">Token para cancelamento da operação.</param>
        /// <returns>Um objeto do tipo PagedResult contendo os DTOs GetSaleItensResponse.</returns>
        Task<PagedResult<GetSaleItensResponse>> GetSalesWithProjectionAsync(
            DateTime dataInicial,
            DateTime dataFinal,
            int page = 1,
            int size = 10,
            string order = "dataVenda asc",
            CancellationToken cancellationToken = default);
    }


}
