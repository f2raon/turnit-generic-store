using MediatR;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class GetAllCategoriesRequest : IRequest<CategoryModel[]>
    {
    }
}
