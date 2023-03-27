namespace CarDealer
{
    using AutoMapper;

    using DTOs.Export;
    using DTOs.Import;
    using Models;
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            CreateMap<SupplierDto, Supplier>();
            CreateMap<Supplier, ExportSuppliersDto>()
                .ForMember(d => d.PartsCount, x => x.MapFrom(s => s.Parts.Count));

            //Part
            CreateMap<PartDto, Part>();
            CreateMap<Part, ExportCarPartDto>();

            //Car
            CreateMap<CarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            CreateMap<Car, ExportCarDto>();
            CreateMap<Car, ExportBmwCarDto>();
            CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts, opt => opt.MapFrom(s => s.PartsCars.Select(pc => pc.Part).OrderByDescending(x => x.Price).ToArray()));

            //Customer
            CreateMap<CustomerDto, Customer>();

            //Sale
            CreateMap<SaleDto, Sale>();
        }
    }
}
