using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Turnit.GenericStore.Api.Models;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Features.Sales;

[Route("products")]
public class ProductsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet, Route("by-category/{categoryId:guid}")]
    public async Task<ProductCategoryModel> ProductsByCategory(Guid categoryId)
    {
        var request = new GetProductsByCategoryRequest(categoryId);
        return await _mediator.Send(request);
    }

    [HttpGet, Route("")]
    public async Task<ProductCategoryModel[]> AllProducts()
    {
        var request = new GetAllProductsRequest();
        return await _mediator.Send(request);
    }

    [HttpPut, Route("{productId:guid}/category/{categoryId:guid}")]
    public async Task AddNewProductToCategory(Guid productId, Guid categoryId)
    {
        var request = new AddNewProductRequest(productId, categoryId);
        await _mediator.Send(request);
    }

    [HttpDelete, Route("{productId:guid}/category/{categoryId:guid}")]
    public async Task RemoveProductFromCategory(Guid productId, Guid categoryId)
    {
        var request = new DeleteProductRequest(productId, categoryId);
        await _mediator.Send(request);
    }

    [HttpPost, Route("{productId:guid}/book")]
    public async Task BookProduct(Guid productId, [FromBody] Dictionary<Guid, int> items)
    {
        var request = new BookProductRequest(productId, items);
        await _mediator.Send(request);
    }
}