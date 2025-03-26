using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Common;
using Ambev.DeveloperEvaluation.Common.DTOs; // DTOs compartilhados
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas aos itens de venda.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SalesItemController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;

        public SalesItemController(IMediator mediator, IMapper mapper, ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo item de venda.
        /// </summary>
        /// <param name="request">A requisição para criação do item de venda.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Detalhes do item de venda criado.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> CreateSaleItem([FromBody] CreateSaleItemRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleItemRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleItemCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
            {
                Success = true,
                Message = "Item de venda criado com sucesso",
                Data = _mapper.Map<CreateSaleItemResponse>(response)
            });
        }

        /// <summary>
        /// Recupera um item de venda pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do item de venda.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Detalhes do item de venda, se encontrado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<DeveloperEvaluation.Common.DTOs.GetSaleItemResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> GetSaleItem([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetSaleItemRequest { Id = id };
            var validator = new GetSaleItemRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleItemCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<DeveloperEvaluation.Common.DTOs.GetSaleItemResponse>
            {
                Success = true,
                Message = "Item de venda recuperado com sucesso",
                Data = _mapper.Map<DeveloperEvaluation.Common.DTOs.GetSaleItemResponse>(response)
            });
        }

        /// <summary>
        /// Deleta um item de venda pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do item de venda a ser deletado.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Mensagem de sucesso se o item for deletado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> DeleteSaleItem([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleItemRequest { Id = id };
            var validator = new DeleteSaleItemRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteSaleItemCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Item de venda deletado com sucesso"
            });
        }

        /// <summary>
        /// Recupera a lista de todas as vendas com seus itens, com paginação, ordenação e filtro por período de data.
        /// </summary>
        /// <param name="page">Número da página (default: 1)</param>
        /// <param name="size">Número de itens por página (default: 10)</param>
        /// <param name="order">Ordenação dos resultados (ex.: "dataVenda asc, clienteId desc")</param>
        /// <param name="dataInicial">Data inicial para filtrar as vendas (obrigatória)</param>
        /// <param name="dataFinal">Data final para filtrar as vendas (obrigatória)</param>
        /// <param name="cancellationToken">Token para cancelamento da requisição</param>
        /// <returns>Uma lista paginada de vendas e seus itens</returns>
        [HttpGet("projection")]
        [ProducesResponseType(typeof(ApiResponseWithData<PagedResult<GetSaleItensResponse>>), 200)]
        public async Task<IActionResult> GetSalesItens(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string order = "dataVenda asc, clienteId desc",
            [FromQuery] DateTime? dataInicial = null,
            [FromQuery] DateTime? dataFinal = null,
            CancellationToken cancellationToken = default)
        {
            // Define valores padrão se não forem informados
            dataInicial ??= DateTime.Today.AddDays(-1);
            dataFinal ??= DateTime.Today;

            // Chama o método de projeção, que já aplica filtragem, ordenação e paginação
            var pagedResult = await _saleRepository.GetSalesWithProjectionAsync(
                dataInicial.Value,
                dataFinal.Value,
                page,
                size,
                order,
                cancellationToken);

            return Ok(new ApiResponseWithData<PagedResult<GetSaleItensResponse>>
            {
                Success = true,
                Message = "Vendas e itens recuperados com sucesso.",
                Data = pagedResult
            });
        }
    }
}

