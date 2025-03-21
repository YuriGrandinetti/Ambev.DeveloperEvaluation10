using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleItemRepository 
    {
        /// <summary>
        /// Obtém um item de venda pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do item de venda.</param>
        /// <returns>O item de venda correspondente ou null, se não encontrado.</returns>
        Task<SaleItem> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtém todos os itens de venda.
        /// </summary>
        /// <returns>Uma coleção de itens de venda.</returns>
        Task<IEnumerable<SaleItem>> GetAllAsync();

        /// <summary>
        /// Adiciona um novo item de venda ao repositório.
        /// </summary>
        /// <param name="saleItem">O item de venda a ser adicionado.</param>
        Task AddAsync(SaleItem saleItem);

        /// <summary>
        /// Atualiza um item de venda existente.
        /// </summary>
        /// <param name="saleItem">O item de venda com as informações atualizadas.</param>
        Task UpdateAsync(SaleItem saleItem);

        /// <summary>
        /// Remove um item de venda com base no seu identificador.
        /// </summary>
        /// <param name="id">O identificador do item de venda a ser removido.</param>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
