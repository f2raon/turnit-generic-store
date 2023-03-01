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
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, ProductCategoryModel[]>
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;

        }

        public async Task<ProductCategoryModel[]> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            Product productAlias = null;
            var productCategories = await _session.QueryOver<ProductCategory>().ListAsync(cancellationToken);
            var uncategorizedProducts = await _session
                .QueryOver(() => productAlias)
                .WhereRestrictionOn(() => productAlias.ProductCategories).IsEmpty
                .ListAsync<Product>(cancellationToken);

            var result = productCategories.GroupBy(e => e.Category.Id)
                .Select(e => new ProductCategoryModel
                {
                    CategoryId = e.Key,
                    Products = e.Select(x => _mapper.Map<ProductModel>(x.Product)).ToArray()
                })
                .ToList();

            if (uncategorizedProducts.Any())
            {
                result.Add(new ProductCategoryModel
                {
                    Products = uncategorizedProducts.Select(e => _mapper.Map<ProductModel>(e)).ToArray()
                });
            }

            return result.ToArray();
        }
    }
}
