using AutoMapper;
using GeepShopping.ProductAPI.Data.ValueObjects;
using GeepShopping.ProductAPI.Model;

namespace GeepShopping.ProductAPI.Config
{
    public class ProductProfile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
