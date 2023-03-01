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
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryRequest, ProductCategoryModel>
    {

        private readonly ISession _session;
        private readonly IMapper _mapper;

        public GetProductsByCategoryHandler(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;

        }

        public async Task<ProductCategoryModel> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
        {
            var products = await _session.QueryOver<ProductCategory>()
           .Where(x => x.Category.Id == request.CategoryId)
           .Select(x => x.Product)
           .ListAsync<Product>(cancellationToken);

            return new ProductCategoryModel
            {
                CategoryId = request.CategoryId,
                Products = products.Select(e => _mapper.Map<ProductModel>(e)).ToArray()
            };
        }
    }
}
