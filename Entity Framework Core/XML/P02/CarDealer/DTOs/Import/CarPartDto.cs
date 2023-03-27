namespace CarDealer.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class CarPartDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
