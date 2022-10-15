//---------------------------------------------------------------------------
// <copyright file="ProductController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Persistence.Contexts;

/// <summary>
/// Product management Rest API controller.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductContext _context;

    public ProductController(ProductContext productCtx)
    {
        _context = productCtx;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductList()
    {
        return Ok(await _context.Products.ToListAsync());
    }
}
