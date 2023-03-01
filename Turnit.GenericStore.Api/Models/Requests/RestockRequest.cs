using MediatR;
using System.Collections.Generic;
using System;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class RestockRequest : IRequest
    {
        public Guid StoreId { get; init; }
        public Dictionary<Guid, int> Items { get; init; } = new();

        public RestockRequest(Guid storeId, Dictionary<Guid, int> items)
        {
            StoreId = storeId;
            Items = items;
        }
    }
}
