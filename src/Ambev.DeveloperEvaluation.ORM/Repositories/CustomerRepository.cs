using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DefaultContext _context;

        public CustomerRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Cliente.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Cliente.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Cliente.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = await _context.Cliente.FindAsync(new object[] { id }, cancellationToken);
            if (customer != null)
            {
                _context.Cliente.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

