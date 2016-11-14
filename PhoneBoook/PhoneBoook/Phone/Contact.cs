using System;

namespace PhoneBoook.Phone
{
    public class Contact
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public Contact()
        {
        }

        public Contact(string name, string city, string phone)
        {
            Name = name;
            City = city;
            Phone = phone;
        }

        public override string ToString()
        {
            return string.Format($"Name: {Name}, City: {City}, Phone: {Phone}");
        }
    }
}
