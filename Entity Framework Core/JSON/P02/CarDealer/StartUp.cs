namespace CarDealer
{
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

            string inputJson = File.ReadAllText("../../../Datasets/cars.json");

            string result = ImportCars(context, inputJson);

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
    }
}