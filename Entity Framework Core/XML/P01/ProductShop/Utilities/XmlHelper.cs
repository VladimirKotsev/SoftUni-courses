namespace ProductShop.Utilities
{
    using System.Xml.Serialization;
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer.Deserialize(reader)!;

            return dtos;
        }

        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            T[] dtos = (T[])xmlSerializer.Deserialize(reader)!;

            return dtos;
        }
    }
}
