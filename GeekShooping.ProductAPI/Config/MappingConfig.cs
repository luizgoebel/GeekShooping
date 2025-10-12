using AutoMapper;
using GeekShooping.ProductAPI.Data.Dto;
using GeekShooping.ProductAPI.Model;

namespace GeekShooping.ProductAPI.Config;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
