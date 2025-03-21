using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.ORM.MongoDb;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.ORM.EventsHandlers
{
    public class SaleCreatedEventHandler : INotificationHandler<SaleCreatedEvent>
    {
        private readonly MongoSaleService _mongoSaleService;
        private readonly ILogger<SaleCreatedEventHandler> _logger;
        public SaleCreatedEventHandler(MongoSaleService mongoSaleService, ILogger<SaleCreatedEventHandler> logger)
        {
            _mongoSaleService = mongoSaleService;
            _logger = logger;
        }

        public async Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processando evento SaleCreated para a venda: {NumeroVenda}", notification.Sale.NumeroVenda);
            await _mongoSaleService.InsertOrUpdateSaleAsync(notification.Sale);
        }
    }
}
