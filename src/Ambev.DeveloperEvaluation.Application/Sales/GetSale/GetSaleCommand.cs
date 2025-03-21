using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        public GetSaleCommand(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of GetUserCommand
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
      


    }
}
