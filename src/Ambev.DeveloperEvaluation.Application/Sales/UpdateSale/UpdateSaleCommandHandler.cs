using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Handler responsável por atualizar os dados de uma venda.
    /// </summary>
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSaleCommandHandler> _logger;

        public UpdateSaleCommandHandler(
            ISaleRepository saleRepository,
            IMapper mapper,
            ILogger<UpdateSaleCommandHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            // Busca a venda pelo ID
            var sale = await _saleRepository.GetByIdAsync(request.Id);
            if (sale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {request.Id} not found.");
            }

            // Aplica o mapeamento do comando para a entidade existente
            _mapper.Map(request, sale);

            // Atualiza a venda no repositório
            await _saleRepository.UpdateAsync(sale);

            _logger.LogInformation("Sale updated with ID {SaleId}", sale.Id);

            // Retorna o resultado
            return _mapper.Map<UpdateSaleResult>(sale);
        }
    }
}

