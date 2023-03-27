namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithPartsDto
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [XmlElement("traveled-distance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public ExportCarPartDto[] Parts { get; set; }
    }
}
