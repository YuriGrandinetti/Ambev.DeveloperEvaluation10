using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent : INotification
    {
        public Sale Sale { get; }

        public SaleCreatedEvent(Sale sale)
        {
            Sale = sale;
        }
    }
}
