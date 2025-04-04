﻿using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.TestData;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateSaleCommandHandler> _logger;
    private readonly CreateSaleCommandHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mediator = Substitute.For<IMediator>();
        _mapper = Substitute.For<IMapper>();
        _logger = Substitute.For<ILogger<CreateSaleCommandHandler>>();

        _handler = new CreateSaleCommandHandler(_saleRepository, _mediator, _mapper, _logger);
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnsSuccessResponseAsync()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        var command = CreateSaleHandlerTestData.GenerateValidCommand(saleId);
        // Garante que o campo obrigatório não esteja em branco
        command.NumeroVenda = "Venda001";

        var sale = new Sale
        {
            Id = saleId,
            NumeroVenda = command.NumeroVenda,
            BranchId = command.BranchId,
            CustomerId = command.CustomerId,
            DataVenda = command.DataVenda,
            ValorTotalVenda = command.ValorTotalVenda,
            Itens= command.Itens
                       
            // ... outros atributos conforme necessário
        };

        var expectedResult = new CreateSaleResult
        {
            Id = sale.Id,
        };
     //   _mapper.Map<User>(command).Returns(user);
        // Configura o mapeamento do comando para a entidade (aceitando qualquer instância do comando)
        _mapper.Map<Sale>(command).Returns(sale);
        // Configura o mapeamento da entidade para o resultado para sempre retornar o expectedResult
        _mapper.Map<CreateSaleResult>(Arg.Any<Sale>()).Returns(expectedResult);

        // Simula a persistência no repositório, retornando a entidade "sale"
        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(sale));

        // Act
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);
        // Use um matcher específico:
        // var createSaleResult = _mapper.Map<CreateSaleResult>(Arg.Is<Sale>(s => s.Id == sale.Id)).Returns(expectedResult);
       // var createSaleResult = _mapper.Map<CreateSaleResult>(Arg.Any<Sale>()).ReturnsForAnyArgs(expectedResult);


        // Assert
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);

        await _saleRepository.Received(1)
            .AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }
}
