namespace ProductShop
{
    using AutoMapper;

    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            this.CreateMap<UserDto, User>();
            this.CreateMap<ProductDto, Product>();
            this.CreateMap<CategoryDto, Category>();
            this.CreateMap<CategoryProductDto, CategoryProduct>();
        }
    }
}
