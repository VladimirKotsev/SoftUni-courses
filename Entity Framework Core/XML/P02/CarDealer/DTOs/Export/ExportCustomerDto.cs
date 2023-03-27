namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ExportCustomerDto
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("bought-cars")]
        public int BoughtCarsCount { get; set; }

        [XmlAttribute("")]
    }
}
