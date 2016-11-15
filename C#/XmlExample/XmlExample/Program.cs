using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace XmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfStudents = new List<Student>();

            //generate students
            for (var i = 0; i < 20; i++)
            {
                var newStudent = StudentFactory.Create();
                listOfStudents.Add(newStudent);
            }

            //create xml manually
            var doc = new XmlDocument();
            var rootEl = doc.CreateElement("students");
            doc.AppendChild(rootEl);

            foreach (var stud in listOfStudents)
            {
                var el = doc.CreateElement("student");
                var att = doc.CreateAttribute("id");
                att.InnerText = stud.Id.ToString();
                el.InnerText = stud.Name;
                el.Attributes.Append(att);
                rootEl.AppendChild(el);
            }
            
            //Save
            doc.Save("../../students.xml");

            //generate xml with serialized list of students
            var ser = new XmlSerializer(typeof(List<Student>));
            using (var xmlWriter = new StreamWriter("../../studentsSerialized.xml"))
            {
                ser.Serialize(xmlWriter, listOfStudents);
            }
            
            //Get XML data from URL
            const string filePath = "http://www.w3schools.com/xsl/books.xml";
            string xmlStr;
            using (var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(filePath);
            }
            var xmlBooksDoc = new XmlDocument();
            xmlBooksDoc.LoadXml(xmlStr);

            //Get bookstore node by xpath
            var store = xmlBooksDoc.SelectSingleNode("bookstore");

            //Print all book names
            if (store != null)
            {
                foreach (XmlNode book in store.ChildNodes)
                {
                    Console.WriteLine("Book name: " + book.InnerText);
                }
            }

            //convert to JSON Newtonsoft.Json
            var json = JsonConvert.SerializeObject(xmlBooksDoc);
            Console.WriteLine(json);
        }
    }
}
