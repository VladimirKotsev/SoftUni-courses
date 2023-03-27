namespace ProductShop
{
    using AutoMapper;
    using System.Text;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    using Utilities;
    using DTOs.Import;
    using DTOs.Export;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext ctx = new ProductShopContext();
            //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            string result = GetProductsInRange(ctx);
            Console.WriteLine(result);
        }

        //Problem 01.
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            UserDto[] userDtos = xmlHelper.Deserialize<UserDto[]>(inputXml, "Users");

            IMapper mapper = InitializeAutoMapper();

            ICollection<User> validUsers = new HashSet<User>();
            foreach (var dto in userDtos)
            {
                if (String.IsNullOrEmpty(dto.FirstName) || String.IsNullOrEmpty(dto.LastName))
                {
                    continue;
                }

                User userToAdd = mapper.Map<User>(dto);
                validUsers.Add(userToAdd);
            }

            context.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //Problem 02.
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ProductDto[] productDtos = xmlHelper.Deserialize<ProductDto[]>(inputXml, "Products");

            IMapper mapper = InitializeAutoMapper();

            ICollection<Product> validProducts = new HashSet<Product>();
            foreach (var dto in productDtos)
            {
                if (String.IsNullOrEmpty(dto.Name) || String.IsNullOrEmpty(dto.Price.ToString()) || String.IsNullOrEmpty(dto.SellerId.ToString()) || String.IsNullOrEmpty(dto.BuyerId.ToString()))
                {
                    continue;
                }

                if (!context.Users.Any(u => u.Id == dto.BuyerId) || !context.Users.Any(u => u.Id == dto.SellerId))
                {
                    continue;
                }

                Product productToAdd = mapper.Map<Product>(dto);
                validProducts.Add(productToAdd);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //Problem 03.
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            CategoryDto[] categoriesDtos = xmlHelper.Deserialize<CategoryDto[]>(inputXml, "Categories");

            IMapper mapper = InitializeAutoMapper();

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (var dto in categoriesDtos)
            {
                if (String.IsNullOrEmpty(dto.Name))
                {
                    continue;
                }

                Category categoryToAdd = mapper.Map<Category>(dto);
                validCategories.Add(categoryToAdd);
            }

            context.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //Problem 04.
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            CategoryProductDto[] categoryProductDtos = xmlHelper.Deserialize<CategoryProductDto[]>(inputXml, "CategoryProducts");

            IMapper mapper = InitializeAutoMapper();

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();
            foreach (var dto in categoryProductDtos)
            {
                if (!context.Products.Any(p => p.Id == dto.ProductId) || !context.Categories.Any(c => c.Id == dto.CategoryId))
                {
                    continue;
                }

                CategoryProduct categoryProductToAdd = mapper.Map<CategoryProduct>(dto);
                validCategoryProducts.Add(categoryProductToAdd);
            }

            context.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //Problem 05.
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            StringBuilder sb = new StringBuilder();

            ExportProductDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    p.Buyer
                })
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductDto[]), xmlRoot);

            StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, products);

            return sb.ToString().TrimEnd();
        }

        //Mapper configuration helper
        public static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(ctg =>
            {
                ctg.AddProfile<ProductShopProfile>();
            }));
    }
}