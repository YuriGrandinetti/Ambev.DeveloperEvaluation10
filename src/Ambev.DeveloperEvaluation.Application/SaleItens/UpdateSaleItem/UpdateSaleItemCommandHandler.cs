using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Handler responsável por atualizar os dados de um item de venda, incluindo a possibilidade de cancelá-lo.
    /// </summary>
    public class UpdateSaleItemCommandHandler : IRequestHandler<UpdateSaleItemCommand, UpdateSaleItemResult>
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSaleItemCommandHandler> _logger;

        public UpdateSaleItemCommandHandler(
            ISaleItemRepository saleItemRepository,
            IMapper mapper,
            ILogger<UpdateSaleItemCommandHandler> logger)
        {
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand request, CancellationToken cancellationToken)
        {
            // Busca o item de venda pelo ID
            var saleItem = await _saleItemRepository.GetByIdAsync(request.Id);
            if (saleItem == null)
            {
                throw new KeyNotFoundException($"Sale item with ID {request.Id} not found.");
            }

            // Aplica o mapeamento do comando para a entidade existente
            _mapper.Map(request, saleItem);

            // Atualiza o item de venda no repositório
            await _saleItemRepository.UpdateAsync(saleItem);

            _logger.LogInformation("Sale item updated with ID {SaleItemId}. Cancelado = {Cancelado}", saleItem.Id, saleItem.Cancelado);

            // Retorna o resultado
            return _mapper.Map<UpdateSaleItemResult>(saleItem);
        }
    }
}

