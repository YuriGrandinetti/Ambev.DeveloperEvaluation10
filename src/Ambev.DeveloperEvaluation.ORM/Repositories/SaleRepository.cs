using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Common.DTOs;
using Ambev.DeveloperEvaluation.Common;
//using System.Linq.Dynamic.Core;
//using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DTOs;
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

        public Task AddAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sale>> GetAllAsync(CancellationToken cancellationToken = default)
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

        //public Task<IEnumerable<GetSaleItensResponse>> GetSalesWithProjectionAsync(DateTime dataInicial, DateTime dataFinal, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

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

        
        public async Task<PagedResult<GetSaleItensResponse>> GetSalesWithProjectionAsync(
           DateTime dataInicial,
           DateTime dataFinal,
           int page = 1,
           int size = 10,
           string order = "dataVenda asc",
           CancellationToken cancellationToken = default)
        {
            // Inicia a query base, incluindo os itens da venda
            var query = _context.Pedido
                .Include(s => s.Itens)
                .AsQueryable();

            // Aplica o filtro pelo intervalo de datas
            query = query.Where(s => s.DataVenda >= dataInicial && s.DataVenda <= dataFinal);

            // Ordenação simples por DataVenda (pode ser aprimorada para interpretar o parâmetro "order")
            query = query.OrderBy(s => s.DataVenda);

            // Conta o total de registros antes de aplicar a paginação
            var totalCount = await query.CountAsync(cancellationToken);

            // Aplica paginação e projeta o resultado para os DTOs
            var sales = await query.Skip((page - 1) * size)
                .Take(size)
                .Select(s => new GetSaleItensResponse
                {
                    Id = s.Id,
                    NumeroVenda = s.NumeroVenda,
                    DataVenda = s.DataVenda,
                    ClienteId = s.CustomerId,
                    ValorTotalVenda = s.ValorTotalVenda,
                    FilialId = s.BranchId,
                    Itens = s.Itens.Select(i => new GetSaleItemResponse
                    {
                        Id = i.Id,
                        ProdutoId = i.ProductId,
                        Quantidade = i.Quantidade,
                        PrecoUnitario = i.PrecoUnitario,
                        DescontoItem = i.DescontoItem,
                        ValorTotalItem = i.ValorTotalItem,
                        Cancelado = i.Cancelado
                    }).ToList()
                })
                .ToListAsync(cancellationToken);

            // Retorna o resultado paginado
            return new PagedResult<GetSaleItensResponse>
            {
                Page = page,
                Size = size,
                Total = totalCount,
                Data = sales
            };
        }

    }
}
