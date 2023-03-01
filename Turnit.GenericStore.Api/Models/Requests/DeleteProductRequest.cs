using MediatR;
using System;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class DeleteProductRequest : IRequest
    {
        public Guid Id { get; init; }
        public Guid CategoryId { get; init; }

        public DeleteProductRequest(Guid id, Guid categoryId)
        {
            Id = id;
            CategoryId = categoryId;
        }
    }
}
