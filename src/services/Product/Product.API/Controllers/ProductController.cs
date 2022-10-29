//---------------------------------------------------------------------------
// <copyright file="ProductController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dtos;
using Product.Application.Features.Products.Queries.GetCategoryList;
using Product.Application.Features.Products.Queries.GetProduct;
using Product.Application.Features.Products.Queries.GetProductList;
using Product.Application.Features.Products.Queries.GetProductsByCategory;

/// <summary>
/// Product management Rest API controller.
/// </summary>
[Route("api/v1")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("products")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductList()
    {
        var result = await _mediator.Send(new GetProductListQuery());

        return Ok(result);
    }

    [HttpGet("category-products/{categoryUrl}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductByCategory(string categoryUrl)
    {
        var result = await _mediator.Send(new GetProductsByCategoryQuery
        {
            CategoryUrl = categoryUrl
        });

        return Ok(result);
    }


    [HttpGet("products/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var result = await _mediator.Send(new GetProductQuery
        {
            ProductId = id
        });

        return Ok(result);
    }

    [HttpGet("category-list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
    public async Task<IActionResult> GetCategoryList()
    {
        var result = await _mediator.Send(new GetCategoryListQuery());

        return Ok(result);
    }
}
