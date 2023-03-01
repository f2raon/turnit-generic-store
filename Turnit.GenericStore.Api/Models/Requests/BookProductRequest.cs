using MediatR;
using System.Collections.Generic;
using System;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class BookProductRequest : IRequest
    {
        public Guid ProductId { get; init; }
        public Dictionary<Guid, int> Items { get; init; } = new();

        public BookProductRequest(Guid productId, Dictionary<Guid, int> items)
        {
            ProductId = productId;
            Items = items;
        }
    }
}
