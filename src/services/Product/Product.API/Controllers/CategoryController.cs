//---------------------------------------------------------------------------
// <copyright file="CategoryController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dtos;
using Product.Application.Features.Products.Queries.GetCategoryList;

/// <summary>
/// Management of product categories.
/// </summary>
[Route("api/v1")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("category-list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
    public async Task<IActionResult> GetCategoryList()
    {
        var result = await _mediator.Send(new GetCategoryListQuery());

        return Ok(result);
    }
}
