using MediatR;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class GetAllProductsRequest : IRequest<ProductCategoryModel[]>
    {
    }
}
