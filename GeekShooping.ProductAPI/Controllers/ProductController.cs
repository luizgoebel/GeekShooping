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
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
    {
        IEnumerable<ProductDto> products = await _productRepository.FindAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(long id)
    {
        ProductDto product = await _productRepository.FindById(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto productDto)
    {
        if (productDto == null)
            return BadRequest();
        ProductDto product = await _productRepository.Create(productDto);
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto productDto)
    {
        if (productDto == null)
            return BadRequest();
        ProductDto product = await _productRepository.Update(productDto);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        bool status = await _productRepository.Delete(id);
        if (!status)
            return NotFound();
        return Ok(status);
    }
}
