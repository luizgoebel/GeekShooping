using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;
using GeekShooping.Web.Utils;

namespace GeekShooping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private const string BasePath = "/api/v1/product";

    public ProductService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        HttpResponseMessage response = await _client.GetAsync(BasePath);
        return await response.ReadContentAs<IEnumerable<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
        HttpResponseMessage response = await _client.GetAsync($"{BasePath}/{id}");
        return await response.ReadContentAs<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel model)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync(BasePath, model);
        response.EnsureSuccessStatusCode();
        ProductModel product = await response.ReadContentAs<ProductModel>();
        return product;
    }

    public async Task<ProductModel> UpdateProduct(ProductModel model)
    {
        HttpResponseMessage response = await _client.PutAsJsonAsync(BasePath, model);
        response.EnsureSuccessStatusCode();
        ProductModel product = await response.ReadContentAs<ProductModel>();
        return product;
    }

    public async Task<bool> DeleteProductById(long id)
    {
        HttpResponseMessage response = await _client.DeleteAsync($"{BasePath}/{id}");
        response.EnsureSuccessStatusCode(); 
        return await response.ReadContentAs<bool>();
    }
}
