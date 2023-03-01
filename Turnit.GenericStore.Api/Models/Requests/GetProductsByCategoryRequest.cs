using MediatR;
using System;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class GetProductsByCategoryRequest : IRequest<ProductCategoryModel>
    {
        public Guid CategoryId { get; init; }

        public GetProductsByCategoryRequest(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
