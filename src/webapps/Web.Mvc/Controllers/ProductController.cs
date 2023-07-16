namespace Web.Mvc.Controllers;

using ApiServices;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    // GET: ProductController1cs
    public async Task<ActionResult> Index()
    {
        var products = await _productService.GetProductAsync(Guid.NewGuid());


        return View(products);
    }
}
