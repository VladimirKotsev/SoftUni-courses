namespace CarDealer
{
    using AutoMapper;
    using System.Text;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Utilities;
    using DTOs.Import;
    using Models;
    using DTOs.Export;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext ctx = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            string result = GetCarsWithTheirListOfParts(ctx);
            Console.WriteLine(result);
        }

        //Problem 09.
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            SupplierDto[] supplierDtos = xmlHelper.Deserialize<SupplierDto[]>(inputXml, "Suppliers");

            IMapper mapper = InitializeMapper();

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
            foreach (var dto in supplierDtos)
            {
                if (String.IsNullOrEmpty(dto.Name))
                {
                    continue;
                }

                Supplier supplierToAdd = mapper.Map<Supplier>(dto);
                validSuppliers.Add(supplierToAdd);
            }

            context.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        //Problem 10.
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            PartDto[] partDtos = xmlHelper.Deserialize<PartDto[]>(inputXml, "Parts");

            IMapper mapper = InitializeMapper();

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (var dto in partDtos)
            {
                if (!context.Suppliers.Any(s => s.Id == dto.SupplierId))
                {
                    continue;
                }

                Part partToAdd = mapper.Map<Part>(dto);
                validParts.Add(partToAdd);
            }

            context.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        //Problem 11.
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            CarDto[] carDtos = xmlHelper.Deserialize<CarDto[]>(inputXml, "Cars");

            IMapper mapper = InitializeMapper();

            ICollection<Car> validCars = new HashSet<Car>();
            foreach (var dto in carDtos)
            {
                Car carToAdd = mapper.Map<Car>(dto);

                foreach (var part in dto.Parts.DistinctBy(x => x.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == part.PartId))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = part.PartId
                    };

                    carToAdd.PartsCars.Add(carPart);
                }

                validCars.Add(carToAdd);
            }

            context.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        //Problem 12.
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            CustomerDto[] customerDtos = xmlHelper.Deserialize<CustomerDto[]>(inputXml, "Customers");

            IMapper mapper = InitializeMapper();

            ICollection<Customer> validCustomer = new HashSet<Customer>();
            foreach (var dto in customerDtos)
            {
                if (String.IsNullOrEmpty(dto.Name)
                    || String.IsNullOrEmpty(dto.BirthDate.ToString())
                    || String.IsNullOrEmpty(dto.IsYoungDriver.ToString()))
                {
                    continue;
                }

                Customer customerToAdd = mapper.Map<Customer>(dto);
                validCustomer.Add(customerToAdd);
            }

            context.AddRange(validCustomer);
            context.SaveChanges();

            return $"Successfully imported {validCustomer.Count}";
        }

        //Problem 13.
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            SaleDto[] saleDtos = xmlHelper.Deserialize<SaleDto[]>(inputXml, "Sales");

            IMapper mapper = InitializeMapper();

            ICollection<Sale> validSales = new HashSet<Sale>();
            foreach (var dto in saleDtos)
            {
                if (!context.Cars.Any(c => c.Id == dto.CarId))
                {
                    continue;
                }

                Sale saleToAdd = mapper.Map<Sale>(dto);
                validSales.Add(saleToAdd);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        //Problem 14.
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .AsNoTracking()
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarDto[]>(cars, "cars");
        }

        //Problem 15.
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportBmwCarDto[] bmws = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBmwCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportBmwCarDto[]>(bmws, "cars");

        }

        //Problem 16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportSuppliersDto[] suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSuppliersDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportSuppliersDto[]>(suppliers, "suppliers");
        }

        //Problem 17.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarWithPartsDto[] cars = context.Cars
                .OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarWithPartsDto[]>(cars, "cars");
        }

        //Problem 18.
        //public static string GetTotalSalesByCustomer(CarDealerContext context)
        //{
        //    IMapper mapper = InitializeMapper();
        //    XmlHelper xmlHelper = new XmlHelper();


        //}

        ////Problem 19.
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();
            XmlHelper xmlHelper = new XmlHelper();


        }

        public static IMapper InitializeMapper()
        => new Mapper(new MapperConfiguration(ctg =>
        {
            ctg.AddProfile<CarDealerProfile>();
        }));
    }
}