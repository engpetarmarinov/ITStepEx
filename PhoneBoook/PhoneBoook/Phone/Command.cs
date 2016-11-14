using System;
using System.Collections.Generic;

namespace PhoneBoook.Phone
{
    public class Command
    {

        public enum Types
        {
            Serialize,
            Find,
            Add
        }

        public static Dictionary<string, Types> Mapper = new Dictionary<string, Types>()
        {
            { "serialize", Types.Serialize },
            { "find", Types.Find },
            { "add", Types.Add }
        };

        public Types Type { get; private set; }
        public string[] Parameters { get; private set; }

        public Command(Types type, string[] parameters)
        {
            Type = type;
            Parameters = parameters;
        }
        
        public void Invoke(Book book)
        {
            switch (this.Type)
            {
                case Types.Add:
                    var contact = new Contact(Parameters[0], Parameters[1], Parameters[2]);
                    book.Add(contact);
                    break;

                case Types.Find:
                    Contact found;
                    if (Parameters.Length == 1)
                    {
                        found = book.Find(Parameters[0]);
                    }
                    else
                    {
                        found = book.Find(Parameters[0],Parameters[1]);
                    }
                    Console.WriteLine(found);
                    break;

                case Types.Serialize:
                    book.Serialize(Parameters[0], Parameters[1], Parameters[2]);
                    break;
            }
        }

    }
}