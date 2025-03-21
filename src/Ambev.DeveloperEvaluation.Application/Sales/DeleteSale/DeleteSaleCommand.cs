using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleCommand : IRequest<DeleteSaleResponse>
    {
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of DeleteUserCommand
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
        public DeleteSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
