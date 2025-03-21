using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
//using Ambev.DeveloperEvaluation.Infrastructure.MongoDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Ambev.DeveloperEvaluation.ORM.MongoDb;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers
{
    /// <summary>
    /// Inicializa os módulos de infraestrutura da aplicação, registrando DbContext, repositórios e serviços.
    /// </summary>
    public class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            // Configura o EF Core para PostgreSQL com a connection string DefaultConnection
            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Registra o DefaultContext como DbContext para injeção de dependências
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());

            // Registro dos repositórios de domínio
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // Configuração e registro do MongoDB
            builder.Services.AddSingleton<IMongoClient>(s =>
                new MongoClient(configuration.GetConnectionString("MongoConnection")));
            builder.Services.AddScoped<MongoSaleService>(s =>
            {
                var client = s.GetRequiredService<IMongoClient>();
                var logger = s.GetRequiredService<ILogger<MongoSaleService>>();
                return new MongoSaleService(client, configuration.GetValue<string>("MongoDatabase"), logger);
            });
        }
    }
}
