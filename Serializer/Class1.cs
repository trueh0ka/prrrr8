namespace Serializer
{
    using System.Xml.Serialization;
    using System.IO;

    public class Serializer<T>
    {
        public static void SerializeToXmlFile(T data, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, data);
            }
        }

        public static T DeserializeFromXmlFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamReader reader = new StreamReader(filename))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}