using System.Collections.Generic;

namespace PhoneBoook.Phone
{
    public class Book
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public void Add(Contact newContact)
        {
            Contacts.Add(newContact);
        }

        public Contact Find(string name)
        {
            var contact = Contacts.Find(c => c.Name == name);
            return contact;
        }

        public Contact Find(string name, string city)
        {
            var contact = Contacts.Find(c => c.Name == name && c.City == city);
            return contact;
        }

        public void Serialize(string name, string path, string serializeType )
        {
            var serializerMapper = new SerializerMapper();
            var serializer = serializerMapper.GetByType(serializeType, path);
            //TODO: filter by name
            serializer.Write<Contact>(Contacts);
        }


    }
}
