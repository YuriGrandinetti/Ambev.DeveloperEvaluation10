using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem
{
    public class CreateSaleItemCommandHandler : IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateSaleItemCommandHandler> _logger;

        public CreateSaleItemCommandHandler(ISaleItemRepository saleItemRepository, IMediator mediator, ILogger<CreateSaleItemCommandHandler> logger)
        {
            _saleItemRepository = saleItemRepository;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand request, CancellationToken cancellationToken)
        {
            // Criação da entidade SaleItem com os dados recebidos no comando.
            var saleItem = new SaleItem
            {
                ProductId = request.ProductId,
                Quantidade = request.Quantidade,
                PrecoUnitario = request.PrecoUnitario,
                DescontoItem = request.DescontoItem, // ou use regras de negócio se necessário
                ValorTotalItem = request.ValorTotalItem,
                Cancelado = request.Cancelado,
                SaleId = request.SaleId
            };

            // Persiste o item de venda no repositório.
            await _saleItemRepository.AddAsync(saleItem);

            // Opcional: publique um evento de criação do item, se necessário.
            // await _mediator.Publish(new SaleItemCreatedEvent(saleItem), cancellationToken);

            _logger.LogInformation("Sale item criado com Id {SaleItemId} para SaleId: {SaleId}", saleItem.Id, saleItem.SaleId);

            // Retorna o resultado com o identificador do item de venda.
            return new CreateSaleItemResult
            {
                Id = saleItem.Id
            };
        }
    }
}
