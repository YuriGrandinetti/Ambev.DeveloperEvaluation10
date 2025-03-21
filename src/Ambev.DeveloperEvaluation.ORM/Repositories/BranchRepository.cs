using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;

        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Branch branch)
        {
            _context.Filial.Add(branch);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await _context.Filial.ToListAsync();
        }

        public async Task<Branch> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Filial.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Branch branch)
        {
            _context.Filial.Update(branch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var branch = await _context.Filial.FindAsync(new object[] { id }, cancellationToken);
            if (branch != null)
            {
                _context.Filial.Remove(branch);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
