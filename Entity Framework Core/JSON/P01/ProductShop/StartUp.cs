namespace ProductShop
{
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using ProductShop.Data;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext ctx = new ProductShopContext();
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");

            string result = GetCategoriesByProductsCount(ctx);
            Console.WriteLine(result);
        }

        //Problems 01-04
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(ctg =>
            {
                ctg.AddProfile<ProductShopProfile>();
            }));

            UserDto[] users = JsonConvert.DeserializeObject<UserDto[]>(inputJson)!;

            ICollection<User> validUsers = new HashSet<User>();
            foreach (var userDto in users)
            {
                var user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(ctg =>
            {
                ctg.AddProfile<ProductShopProfile>();
            }));

            ProductDto[] products = JsonConvert.DeserializeObject<ProductDto[]>(inputJson)!;

            ICollection<Product> validProducts = new HashSet<Product>();
            foreach (var productDto in products)
            {
                var product = mapper.Map<Product>(productDto);

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(ctg =>
            {
                ctg.AddProfile<ProductShopProfile>();
            }));

            CategoryDto[] categoryDto = JsonConvert.DeserializeObject<CategoryDto[]>(inputJson)!;

            ICollection<Category> categories = new HashSet<Category>();
            foreach (var dto in categoryDto)
            {
                if (dto.Name != null)
                {
                    Category category = mapper.Map<Category>(dto);

                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(ctg =>
            {
                ctg.AddProfile<ProductShopProfile>();
            }));

            CategoryProductDto[] categoryPreoductDto = JsonConvert.DeserializeObject<CategoryProductDto[]>(inputJson)!;

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();
            foreach (var item in categoryPreoductDto)
            {
                if (context.Categories.Any(c => c.Id == item.CategoryId) && context.Products.Any(p => p.Id == item.ProductId))
                {
                    CategoryProduct product = mapper.Map<CategoryProduct>(item);

                    validCategoryProducts.Add(product);
                }
            }
            
            context.CategoriesProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count()}";
        }

        //Problems 05-08
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(products);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(x => x.Buyer != null && x.Seller != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(x => x.Buyer != null)
                        .Select(x => new
                        {
                            name = x.Name,
                            price = x.Price,
                            buyerFirstName = x.Buyer!.FirstName,
                            buyerLastName = x.Buyer!.LastName,
                        })
                        .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;


        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count())
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count(),
                    averagePrice = $"{c.CategoriesProducts.Average(x => x.Product.Price):f2}",
                    totalRevenue = $"{c.CategoriesProducts.Sum(x => x.Product.Price):f2}"
                })
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(x => x.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(x => x.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(x => x.Buyer != null),
                        products = u.ProductsSold
                            .Where(x => x.Buyer != null)
                            .Select(x => new
                            {
                                name = x.Name,
                                price = $"{x.Price:f2}"
                            })
                            .ToArray()
                    }
                    
                })
                .ToArray();

            var userDto = new
            {
                usersCount = users.Length,
                users = users
            };

            string json = JsonConvert.SerializeObject(userDto, Formatting.Indented);

            return json;
        }

    }
}