namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    using CarDealer.Models;

    [XmlType("supplier")]
    public class ExportSuppliersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }

    }
}
