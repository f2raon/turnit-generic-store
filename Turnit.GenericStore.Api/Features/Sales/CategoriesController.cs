using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turnit.GenericStore.Api.Models;
using Turnit.GenericStore.Api.Models.Requests;

namespace Turnit.GenericStore.Api.Features.Sales;

[Route("categories")]
public class CategoriesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet, Route("")]
    public async Task<CategoryModel[]> AllCategories()
    {
        var request = new GetAllCategoriesRequest();
        return await _mediator.Send(request);
    }
}