using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.TestData;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
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

        _handler = new CreateSaleCommandHandler(_saleRepository, _mediator,  _logger);
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnsSuccessResponseAsync()
    {
        // Arrange
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale { Id = Guid.NewGuid(), NumeroVenda = command.NumeroVenda, /* ... */ };
        var result = new CreateSaleResult { Id = sale.Id };

        // Simula mapeamento do comando para a entidade
        _mapper.Map<Sale>(command).Returns(sale);
        // Simula mapeamento da entidade para o resultado
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        // Simula persistência no repositório
        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(sale));

        // Act
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Assert
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);

        await _saleRepository.Received(1)
            .AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    // Outros testes...
}
