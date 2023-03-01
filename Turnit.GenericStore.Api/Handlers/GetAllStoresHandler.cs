using AutoMapper;
using MediatR;
using NHibernate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Handlers
{
    public class GetAllStoresHandler : IRequestHandler<GetAllStoresRequest, StoreModel[]>
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public GetAllStoresHandler(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<StoreModel[]> Handle(GetAllStoresRequest request, CancellationToken cancellationToken)
        {
            var stores = await _session.QueryOver<Store>()
                .ListAsync<Store>(cancellationToken);

            return stores.Select(e => _mapper.Map<StoreModel>(e)).ToArray();
        }
    }
}
