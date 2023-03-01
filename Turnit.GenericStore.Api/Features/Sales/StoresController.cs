using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Turnit.GenericStore.Api.Models;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Features.Sales;

[Route("stores")]
public class StoresController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public StoresController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet, Route("")]
    public async Task<StoreModel[]> AllStores()
    {
        var request = new GetAllStoresRequest();
        return await _mediator.Send(request);
    }

    [HttpPost, Route("{storeId:guid}/restock")]
    public async Task Restock(Guid storeId, [FromBody] Dictionary<Guid, int> items)
    {
        var request = new RestockRequest(storeId, items);
        await _mediator.Send(request);
    }
}