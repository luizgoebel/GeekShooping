using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
       IEnumerable<ProductModel> products = await _productService.FindAllProducts();
        return View(products ?? []);
    }
}
