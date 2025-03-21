using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.DeleteSaleItem;


namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas aos itens de venda (SaleItem).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SalesItemController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SalesItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo item de venda.
        /// </summary>
        /// <param name="request">A requisição para criação do item de venda.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Detalhes do item de venda criado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
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
        /// Obtém um item de venda pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do item de venda.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Detalhes do item de venda, se encontrado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSaleItem([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetSaleItemRequest { Id = id };
            var validator = new GetSaleItemRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleItemCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetSaleItemResponse>
            {
                Success = true,
                Message = "Item de venda recuperado com sucesso",
                Data = _mapper.Map<GetSaleItemResponse>(response)
            });
        }

        /// <summary>
        /// Deleta um item de venda pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do item de venda a ser deletado.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Mensagem de sucesso se o item for deletado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
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
    }
}
