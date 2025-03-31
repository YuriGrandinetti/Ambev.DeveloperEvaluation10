using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.BusinessRules;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateSaleCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateSaleCommandHandler(ISaleRepository saleRepository, IMediator mediator, IMapper mapper, ILogger<CreateSaleCommandHandler> logger)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger ;
        }

        //public CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CreateSaleCommandHandler> logger = null)
        //{
        //    _saleRepository = saleRepository;
        //    _mapper = mapper;
        //    _logger = logger ?? NullLogger<CreateSaleCommandHandler>.Instance;
        //}



        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {

            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //var existingUser = await _saleRepository.GetByEmailAsync(command.Email, cancellationToken);
            //if (existingUser != null)
            //    throw new InvalidOperationException($"User with email {command.Email} already exists");

            var sale = _mapper.Map<Sale>(command);
            // user.Password = _passwordHasher.HashPassword(command.Password);
            //// Persiste a venda no PostgreSQL
            await _saleRepository.AddAsync(sale);

            //// Publica o evento de criação da venda
            await _mediator.Publish(new SaleCreatedEvent(sale), cancellationToken);
            _logger.LogInformation("Evento SaleCreated publicado para a venda: {NumeroVenda}", sale.NumeroVenda);

            //// Retorna um objeto do tipo CreateSaleResult
            return new CreateSaleResult
            {
                Id = sale.Id
            };

            //   var createdSale = await _saleRepository.AddAsync(user, cancellationToken);
            //   var result = _mapper.Map<CreateUserResult>(createdUser);
            //   return result;
            // Criação da entidade Sale
            //var sale = new Sale
            //{
            //    NumeroVenda = request.NumeroVenda,
            //    DataVenda = request.DataVenda,
            //    CustomerId = request.CustomerId,
            //    BranchId = request.BranchId,
            //    ValorTotalVenda = request.ValorTotalVenda,
            //    Itens = request.Itens.Select(item => new SaleItem
            //    {
            //        SaleId = item.SaleId, // Atribui o Id da venda a cada item
            //        ProductId = item.ProductId,
            //        Quantidade = item.Quantidade,
            //        PrecoUnitario = item.PrecoUnitario,
            //        DescontoItem = SaleBusinessRules.CalculateDiscount(item.Quantidade, item.PrecoUnitario, item.Quantidade * item.PrecoUnitario),
            //        ValorTotalItem = item.ValorTotalItem,
            //        Cancelado = item.Cancelado,

            //      //  Sale = item.Sale     // (Opcional) Define a propriedade de navegação para a venda

            //    }).ToList()
            //};

            //// Valida a quantidade dos itens utilizando a regra de negócio
            //SaleBusinessRules.ValidateSaleItemQuantity(sale.Itens);

            //// Persiste a venda no PostgreSQL
            //await _saleRepository.AddAsync(sale);

            //// Publica o evento de criação da venda
            //await _mediator.Publish(new SaleCreatedEvent(sale), cancellationToken);
            //_logger.LogInformation("Evento SaleCreated publicado para a venda: {NumeroVenda}", sale.NumeroVenda);

            //// Retorna um objeto do tipo CreateSaleResult
            //return new CreateSaleResult
            //{
            //    Id = sale.Id
            //};
        }

    }
}
