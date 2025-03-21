using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.DeleteSaleItem
{
    public class DeleteSaleIttemHandler : IRequestHandler<DeleteSaleItemCommand, DeleteSaleItemResponse>
    {
        private readonly ISaleItemRepository _saleItemRepository;

        public DeleteSaleIttemHandler(ISaleItemRepository saleItemRepository)
        {
            _saleItemRepository = saleItemRepository;
        }

        public async Task<DeleteSaleItemResponse> Handle(DeleteSaleItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSalerItemValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors.ToString());

            var success = await _saleItemRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Item SaleItem with ID {request.Id} not found");

            return new DeleteSaleItemResponse { Success = true };
        }
    }
}
