using MediatR;
using NHibernate;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Handlers
{
    public class RestockHandler : IRequestHandler<RestockRequest>
    {
        private readonly ISession _session;

        public RestockHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(RestockRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _session.BeginTransaction())
            {
                foreach (var item in request.Items)
                {
                    var productAvailability = await _session.QueryOver<ProductAvailability>()
                        .Where(e => e.Store.Id == request.StoreId)
                        .And(e => e.Product.Id == item.Key)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (productAvailability == null)
                    {
                        var product = await _session.QueryOver<Product>()
                            .Where(e => e.Id == item.Key)
                            .SingleOrDefaultAsync(cancellationToken)
                            ?? throw new Exception("Product does not exists.");

                        var store = await _session.QueryOver<Store>()
                            .Where(e => e.Id == request.StoreId)
                            .SingleOrDefaultAsync(cancellationToken)
                            ?? throw new Exception("Store does not exists.");

                        productAvailability = new ProductAvailability
                        {
                            Product = product,
                            Store = store,
                        };
                    }

                    productAvailability.Availability += item.Value;
                    await _session.SaveOrUpdateAsync(productAvailability, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }
        }
    }
}
