using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    using System;
    using Xunit;
    using NSubstitute;

    using global::Ambev.DeveloperEvaluation.Domain.Entities;
    using global::Ambev.DeveloperEvaluation.Domain.Repositories;
    
    using global::Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
    using AutoMapper;
    using global::Ambev.DeveloperEvaluation.Unit.TestData;
    using FluentAssertions;
    using global::Ambev.DeveloperEvaluation.Application.Users.CreateUser;
    using global::Ambev.DeveloperEvaluation.ORM.Repositories;
    using global::Ambev.DeveloperEvaluation.Unit.Domain;

    namespace Ambev.DeveloperEvaluation.Unit
    {
        public class CreateSaleHandlerTests
        {
            private readonly ISaleRepository _saleRepository; // Dependência simulada
            private readonly IMapper _mapper;
            private readonly CreateSaleCommandHandler _handler;

            public CreateSaleHandlerTests()
            {
                _saleRepository = Substitute.For<ISaleRepository>();
                _mapper = Substitute.For<IMapper>();
                _handler = new CreateSaleCommandHandler(_saleRepository, _mapper);
            }

            [Fact]
            public async Task Handle_ValidRequest_ReturnsSuccessResponseAsync()
            {
                // Arrange
                var command = CreateSaleHandlerTestData.GenerateValidCommand();

                var sale = new Sale(Guid.NewGuid(), command.DataVenda)
                {
                    Id = Guid.NewGuid(),
                    NumeroVenda = command.NumeroVenda,
                    DataVenda = command.DataVenda,
                    CustomerId = command.CustomerId,
                    BranchId = command.BranchId,
                    ValorTotalVenda = command.ValorTotalVenda                    
                };

                var result = new CreateSaleResult
                {
                    Id = sale.Id,
                };


                _mapper.Map<Sale>(command).Returns(sale);
                _mapper.Map<CreateSaleResult>(sale).Returns(result);

                _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                    .Returns(Task.FromResult(sale));


                // When
                var createSaleResult = await _handler.Handle(command, CancellationToken.None);

                // Then
                createSaleResult.Should().NotBeNull();
                createSaleResult.Id.Should().Be(sale.Id);
                await _saleRepository.Received(1).AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
            }

            [Fact]
            public async Task Handle_InvalidRequest_ThrowsValidationExceptiondosAsync()
            {
                // Given
                var command = new CreateSaleCommand(); // Empty command will fail validation

                // When
                var act = () => _handler.Handle(command, CancellationToken.None);

                // Then
                await act.Should().ThrowAsync<FluentValidation.ValidationException>();
            }

            public async Task Handle_ValidRequest_MapsCommandToUser()
            {
                // Given
                var command = CreateSaleHandlerTestData.GenerateValidCommand();
                var sale = new Sale(Guid.NewGuid(), command.DataVenda)
                {
                    Id = Guid.NewGuid(),
                    NumeroVenda = command.NumeroVenda,
                    DataVenda = command.DataVenda,
                    CustomerId = command.CustomerId,
                    BranchId = command.BranchId,
                    ValorTotalVenda = command.ValorTotalVenda
                };

                _mapper.Map<Sale>(command).Returns(sale);
                _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                    .Returns(Task.FromResult(sale));


                // When
                await _handler.Handle(command, CancellationToken.None);

                // Then
                _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
                    c.DataVenda == command.DataVenda &&
                    c.NumeroVenda == command.NumeroVenda &&
                    c.ValorTotalVenda == command.ValorTotalVenda &&
                    c.BranchId == command.BranchId &&
                    c.CustomerId == command.CustomerId));
            }
        }
    }

}
