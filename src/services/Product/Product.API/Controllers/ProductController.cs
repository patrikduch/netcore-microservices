//---------------------------------------------------------------------------
// <copyright file="ProductController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------
namespace Product.API.Controllers;

using Application.Products.Dtos;
using Application.Products.UseCases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [Authorize]
    [HttpPost("add-product")]
    public async Task<IActionResult> AddProduct()
    {
        return Ok("Added product");
    }

    [Authorize("ClientIdPolicy")]
    [HttpGet("products")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
    public async Task<IActionResult> GetProductList()
    {
        var result = await _mediator.Send(new GetProductListUseCase());

        return Ok(result);
    }

    [HttpGet("category-products/{categoryUrl}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductByCategory(string categoryUrl)
    {
        var result = await _mediator.Send(new GetProductsByCategoryUseCase()
        {
            CategoryUrl = categoryUrl
        });

        return Ok(result);
    }

    [HttpGet("product-search/{searchText}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchProducts(string searchText)
    {
        var result = await _mediator.Send(new SearchProductsUseCase()
        {
            SearchText = searchText
        });

        return Ok(result);
    }

    [HttpGet("product-suggestions/{searchText}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductSearchSuggestions(string searchText)
    {
        var result = await _mediator.Send(new GetProductsSuggestionsUseCase()
        {
            SearchText = searchText
        });

        return Ok(result);
    }

    [HttpGet("products/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var result = await _mediator.Send(new GetProductUseCase()
        {
            ProductId = id
        });

        return Ok(result);
    }
}