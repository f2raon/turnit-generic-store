using AutoMapper;
using MediatR;
using NHibernate;
using System;
using System.Threading;
using System.Threading.Tasks;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Handlers
{
    public class AddNewProductHandler : IRequestHandler<AddNewProductRequest>
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public AddNewProductHandler(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task Handle(AddNewProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _session.QueryOver<Product>()
                .Where(e => e.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken)
                ?? throw new Exception("Product does not exists.");

            var category = await _session.QueryOver<Category>()
                .Where(e => e.Id == request.CategoryId)
                .SingleOrDefaultAsync(cancellationToken)
                ?? throw new Exception("Category does not exists.");

            var productCategory = new ProductCategory
            {
                Category = category,
                Product = product
            };

            product.ProductCategories.Add(productCategory);
            using (var transaction = _session.BeginTransaction())
            {
                await _session.UpdateAsync(product, cancellationToken);
                await _session.SaveAsync(productCategory, cancellationToken);
                transaction.Commit();
            }
        }
    }
}
