using AutoMapper;
using GeekShooping.ProductAPI.Data.Dto;
using GeekShooping.ProductAPI.Model;
using GeekShooping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly MySQLContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(MySQLContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDto> Create(ProductDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<ProductDto>> FindAll()
    {
        IEnumerable<Product> products = await _context.Products.AsNoTracking().ToListAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> FindById(long id)
    {
        Product product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        return product is null ? null : _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> Update(ProductDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }
}
