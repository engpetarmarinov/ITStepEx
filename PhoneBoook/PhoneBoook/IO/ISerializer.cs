using System.Collections.Generic;

namespace PhoneBoook.IO
{
    public interface ISerializer
    {
        string Serialize<T>(List<T> list);
        void Write<T>(List<T> list);
    }
}