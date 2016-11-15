using System.Collections.Generic;
using PhoneBoook.IO;
using System;

namespace PhoneBoook.Phone
{
    public class SerializerMapper
    {
        public enum Type
        {
            Json,
            Xml
        }

        protected Dictionary<string, Type> SerializerMap = new Dictionary<string, Type>()
        {
            { "json",  Type.Json },
            { "xml" , Type.Xml }
        };

        public ISerializer GetByType(string type, string path)
        {
            type = type.ToLower();
            if (SerializerMap.ContainsKey(type))
            {
                return GetSerializer(SerializerMap[type], path);
            }
            throw new ArgumentException("No such type of serializer.");
        }

        public ISerializer GetSerializer(Type type, string pathToWrite)
        {
            switch (type)
            {
                case Type.Json:
                    return new IO.Json(null, pathToWrite);
                case Type.Xml:
                    return new IO.Xml(null, pathToWrite);
                default:
                    throw new ArgumentException("No such type of serializer.");
            }

        }
    }
}