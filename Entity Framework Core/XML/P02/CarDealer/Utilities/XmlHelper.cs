namespace CarDealer.Utilities
{
    using System.Text;
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

        public string Serialize<T>(T obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
