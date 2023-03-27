namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    using ProductShop.Models;

    [XmlType("Product")]
    public class ExportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        public virtual User Buyer { get; set; } = null!;

        [XmlElement("buyer")]
        public string BuyerFullName 
        { 
            get
            {
                return this.Buyer.FirstName + " " + this.Buyer.LastName;
            }
        } 

    }
}
