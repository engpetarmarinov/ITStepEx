using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PhoneBoook.IO
{
    public class Xml : File, ISerializer
    {
        public Xml(string readFromPath = null, string writeToPath = null) : base(readFromPath, writeToPath)
        {
            
        }

        public string Serialize<T>(List<T> list)
        {
            //create the serialiser to create the xml
            var serializer = new XmlSerializer(typeof(List<T>));

            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, list);
                return stringWriter.ToString();
            }
        }

        public void Write<T>(List<T> list)
        {
            //create the serialiser to create the xml
            var serializer = new XmlSerializer(typeof(List<T>));

            //write to the file
            serializer.Serialize(FsWriter, list);
        }
    }
}
