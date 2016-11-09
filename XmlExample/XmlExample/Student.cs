using System.Xml.Serialization;
namespace XmlExample
{
    public class Student
    {
        [XmlElement(ElementName = "student")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}
