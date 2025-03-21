using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Sale>> GetAllAsync();
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
