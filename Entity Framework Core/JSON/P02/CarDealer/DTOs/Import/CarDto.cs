using CarDealer.Models;

namespace CarDealer.DTOs.Import
{
    public class CarDto
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TravelledDistance { get; set; }

        public virtual ICollection<Part> PartsCars { get; set; } = new List<Part>();
    }
}
