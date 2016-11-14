using System.Collections.Generic;
using Newtonsoft.Json;

namespace PhoneBoook.IO
{
    public class Json : File, ISerializer
    {
        public Json(string readFromPath = null, string writeToPath = null) : base(readFromPath, writeToPath)
        {

        }

        public string Serialize<T>(List<T> list)
        {
            return JsonConvert.SerializeObject(list, Formatting.Indented);
        }

        public void Write<T>(List<T> list)
        {
            //serialize into json
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);

            //write to the file
            Write(json);
        }
    }
}