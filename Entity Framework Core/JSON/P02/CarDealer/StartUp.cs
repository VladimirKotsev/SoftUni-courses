namespace CarDealer
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using AutoMapper;

    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string inputJson = File.ReadAllText("../../../Datasets/sales.json");

            string result = GetCarsFromMakeToyota(context);

            Console.WriteLine(result);
        }

        //Problem 09-13
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            SupplierDto[] supplierDtos = JsonConvert.DeserializeObject<SupplierDto[]>(inputJson)!;

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            PartDto[] partDtos = JsonConvert.DeserializeObject<PartDto[]>(inputJson)!;

            ICollection<Part> parts = new HashSet<Part>();
            foreach (var dto in partDtos)
            {
                if (context.Suppliers.Any(x => x.Id == dto.SupplierId))
                {
                    Part part = mapper.Map<Part>(dto);

                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            CarDto[] carDtos = JsonConvert.DeserializeObject<CarDto[]>(inputJson)!;

            ICollection<Car> cars = new HashSet<Car>();
            foreach (var dto in carDtos)
            {
                Car car = mapper.Map<Car>(dto);

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            CustomerDto[] customerDtos = JsonConvert.DeserializeObject<CustomerDto[]>(inputJson)!;

            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            SaleDto[] saleDtos = JsonConvert.DeserializeObject<SaleDto[]>(inputJson)!;

            ICollection<Sale> validSales = new HashSet<Sale>();
            foreach (var dto in saleDtos)
            {
                if (context.Customers.Any(x => x.Id == dto.CustomerId) && context.Cars.Any(x => x.Id == dto.CarId))
                {
                    Sale sale = mapper.Map<Sale>(dto);

                    validSales.Add(sale);
                }
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        //Problem 14-19
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .AsNoTracking()
                .OrderBy(c => c.BirthDate)
                .ThenByDescending(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .AsNoTracking()
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
    }
}