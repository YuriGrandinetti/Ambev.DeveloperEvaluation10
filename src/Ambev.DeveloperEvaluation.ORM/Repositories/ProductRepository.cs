using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            _context.Produto.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Produto.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Produto.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await _context.Produto.FindAsync(new object[] { id }, cancellationToken);
            if (product != null)
            {
                _context.Produto.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

