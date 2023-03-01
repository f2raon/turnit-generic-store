using MediatR;
using System;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class AddNewProductRequest : IRequest
    {
        public Guid Id { get; init; }
        public Guid CategoryId { get; init; }

        public AddNewProductRequest(Guid id, Guid categoryId)
        {
            Id = id;
            CategoryId = categoryId;
        }
    }
}
