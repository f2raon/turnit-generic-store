using MediatR;
using NHibernate;
using System;
using System.Threading;
using System.Threading.Tasks;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Handlers
{
    public class BookProductHandler : IRequestHandler<BookProductRequest>
    {
        private readonly ISession _session;

        public BookProductHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(BookProductRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _session.BeginTransaction())
            {
                foreach (var item in request.Items)
                {
                    var productAvailability = await _session.QueryOver<ProductAvailability>()
                        .Where(e => e.Store.Id == item.Key)
                        .And(e => e.Product.Id == request.ProductId)
                        .SingleOrDefaultAsync(cancellationToken)
                        ?? throw new Exception("Store does not exists.");

                    if (productAvailability.Availability < item.Value)
                    {
                        throw new Exception("Requested quantity is more than left in the stock.");
                    }

                    productAvailability.Availability -= item.Value;

                    await _session.UpdateAsync(productAvailability, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }
        }
    }
}
