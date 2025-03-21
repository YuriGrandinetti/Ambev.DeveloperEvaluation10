using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Sale sale)
        {
            _context.Pedido.Add(sale);
            await _context.SaveChangesAsync();
        }

      

       

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Pedido
               .Include(s => s.Itens)
               .ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Pedido
                .Include(s => s.Itens)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public Task<Sale> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Pedido.Update(sale);
            await _context.SaveChangesAsync();
        }

        async Task<bool> ISaleRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var sale = await _context.Pedido.FindAsync(id);
            if (sale != null)
            {
                _context.Pedido.Remove(sale);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
