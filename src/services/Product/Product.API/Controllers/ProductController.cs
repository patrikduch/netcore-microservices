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
using Product.Application.Features.Products.Queries.GetProduct;
using Product.Application.Features.Products.Queries.GetProductList;
using Product.Application.Features.Products.Queries.GetProductsByCategory;
using Product.Application.Features.Products.Queries.GetProductSuggestions;
using Product.Application.Features.Products.Queries.SearchProducts;

/// <summary>
/// Management of products.
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
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

    [HttpGet("product-search/{searchText}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchProducts(string searchText)
    {
        var result = await _mediator.Send(new SearchProductsQuery
        {
            SearchText = searchText
        });

        return Ok(result);
    }

    [HttpGet("product-suggestions/{searchText}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductSearchSuggestions(string searchText)
    {
        var result = await _mediator.Send(new GetProductSuggestionsQuery
        {
            SearchText = searchText
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
}
