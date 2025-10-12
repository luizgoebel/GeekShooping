using GeekShooping.ProductAPI.Data.Dto;
using GeekShooping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository ??
            throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        IEnumerable<ProductDto> products = await _productRepository.FindAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(long id)
    {
        ProductDto product = await _productRepository.FindById(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}
