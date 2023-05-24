using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

public class Serializer<T>
{
    public static string Serialize(T obj)
    {
        using (var memoryStream = new MemoryStream())
        {
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(memoryStream, obj);
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }

    public static T Deserialize(string str)
    {
        using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
        {
            var serializer = new DataContractSerializer(typeof(T));
            return (T)serializer.ReadObject(memoryStream);
        }
    }
}