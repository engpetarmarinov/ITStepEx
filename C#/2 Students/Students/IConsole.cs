using System;

namespace Students
{
    public interface IConsole
    {
        void Write(string str);
        void WriteLine(string str);
        string ReadLine();
    }
}