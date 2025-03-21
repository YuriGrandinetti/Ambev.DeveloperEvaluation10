using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.BusinessRules;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateSaleCommandHandler> _logger;

        public CreateSaleCommandHandler(ISaleRepository saleRepository, IMediator mediator, ILogger<CreateSaleCommandHandler> logger)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            // Criação da entidade Sale
            var sale = new Sale
            {
                NumeroVenda = request.NumeroVenda,
                DataVenda = request.DataVenda,
                CustomerId = request.CustomerId,
                BranchId = request.BranchId,
                ValorTotalVenda = request.ValorTotalVenda,
                Itens = request.Itens.Select(item => new SaleItem
                {
                    ProductId = item.ProductId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                    DescontoItem = SaleBusinessRules.CalculateDiscount(item.Quantidade, item.PrecoUnitario, item.Quantidade * item.PrecoUnitario),
                    ValorTotalItem = item.ValorTotalItem,
                    Cancelado = item.Cancelado,
                    SaleId = item.SaleId, // Atribui o Id da venda a cada item
                  //  Sale = item.Sale     // (Opcional) Define a propriedade de navegação para a venda

                }).ToList()
            };

            // Valida a quantidade dos itens utilizando a regra de negócio
            SaleBusinessRules.ValidateSaleItemQuantity(sale.Itens);

            // Persiste a venda no PostgreSQL
            await _saleRepository.AddAsync(sale);

            // Publica o evento de criação da venda
            await _mediator.Publish(new SaleCreatedEvent(sale), cancellationToken);
            _logger.LogInformation("Evento SaleCreated publicado para a venda: {NumeroVenda}", sale.NumeroVenda);

            // Retorna um objeto do tipo CreateSaleResult
            return new CreateSaleResult
            {
                Id = sale.Id
            };
        }
        
    }
}
