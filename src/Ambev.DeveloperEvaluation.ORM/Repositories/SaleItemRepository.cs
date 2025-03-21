using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SaleItem saleItem)
        {
            _context.ItensPedido.Add(saleItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SaleItem>> GetAllAsync()
        {
            return await _context.ItensPedido.ToListAsync();
        }

        public async Task<SaleItem> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ItensPedido
                .FirstOrDefaultAsync(si => si.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(SaleItem saleItem)
        {
            _context.ItensPedido.Update(saleItem);
            await _context.SaveChangesAsync();
        }

        
        async Task<bool> ISaleItemRepository.DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var saleItem = await _context.ItensPedido.FindAsync(new object[] { id }, cancellationToken);
            if (saleItem != null)
            {
                _context.ItensPedido.Remove(saleItem);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}

