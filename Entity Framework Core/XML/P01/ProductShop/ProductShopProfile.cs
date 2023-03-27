namespace ProductShop
{
    using AutoMapper;

    using DTOs.Import;
    using Models;
    using DTOs.Export;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            CreateMap<UserDto, User>();

            //Product
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ExportProductDto>();

            //Category
            CreateMap<CategoryDto, Category>();

            //CategoryProducts
            CreateMap<CategoryProductDto, CategoryProduct>();
        }
    }
}
