using MediatR;

namespace Turnit.GenericStore.Api.Models.Requests
{
    public class GetAllStoresRequest : IRequest<StoreModel[]>
    {
    }
}
