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

    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductModel model)
    {
        if (ModelState.IsValid)
        {
            ProductModel response = await _productService.CreateProduct(model);
            if (response != null)
                return RedirectToAction(nameof(ProductIndex));
        }

        return View(model);
    }

    public async Task<IActionResult> ProductUpdate(long id)
    {
        ProductModel model = await _productService.FindProductById(id);
        if (model != null)
            return View(model);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductModel model)
    {
        if (ModelState.IsValid)
        {
            ProductModel response = await _productService.UpdateProduct(model);
            if (response != null)
                return RedirectToAction(nameof(ProductIndex));
        }

        return View(model);
    }

    public async Task<IActionResult> ProductDelete(long id)
    {
        ProductModel model = await _productService.FindProductById(id);
        if (model != null)
            return View(model);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductDelete(ProductModel model)
    {
            bool response = await _productService.DeleteProductById(model.Id);
            if (response)
                return RedirectToAction(nameof(ProductIndex));

        return View(model);
    }
}
