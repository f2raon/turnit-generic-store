using MediatR;
using NHibernate;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest>
    {
        private readonly ISession _session;

        public DeleteProductHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _session.QueryOver<Product>()
                .Where(e => e.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken) 
                ?? throw new Exception("Product does not exists.");

            var productCategory = product.ProductCategories.FirstOrDefault(e => e.Category.Id == request.CategoryId)
                ?? throw new Exception("Product does not belong to the specified Category.");

            using (var transaction = _session.BeginTransaction())
            {
                await _session.DeleteAsync(productCategory, cancellationToken);
                transaction.Commit();
            }
        }
    }
}
