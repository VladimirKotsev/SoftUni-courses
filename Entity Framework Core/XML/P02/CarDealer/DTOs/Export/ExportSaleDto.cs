namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    using Models;

    [XmlType("sale")]
    public class ExportSaleDto
    {
        [XmlElement("car")]
        public Car Car { get; set; } = null!;

        [XmlElement("discount")]
        public decimal Discount { get; set; }
    }
}
