using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.ORM.MongoDb
{
    public class MongoSaleService 
    {
        private readonly IMongoCollection<Sale> _salesCollection;
        private readonly ILogger<MongoSaleService> _logger;

        public MongoSaleService(IMongoClient mongoClient, string databaseName, ILogger<MongoSaleService> logger)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _salesCollection = database.GetCollection<Sale>("Pedido");
            _logger = logger;
        }
        public async Task InsertOrUpdateSaleAsync(Sale sale)
        {
            var filter = Builders<Sale>.Filter.Eq(s => s.Id, sale.Id);
            var options = new ReplaceOptions { IsUpsert = true };
            await _salesCollection.ReplaceOneAsync(filter, sale, options);
            _logger.LogInformation("Venda sincronizada no MongoDB: {NumeroVenda}", sale.NumeroVenda);
        }
    }
}
