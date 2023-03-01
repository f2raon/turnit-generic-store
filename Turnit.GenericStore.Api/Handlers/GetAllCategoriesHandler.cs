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
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, CategoryModel[]>
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<CategoryModel[]> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _session.QueryOver<Category>()
                .OrderBy(e => e.Name).Asc
                .ListAsync<Category>(cancellationToken);

            return categories.Select(e => _mapper.Map<CategoryModel>(e)).ToArray();
        }
    }
}
