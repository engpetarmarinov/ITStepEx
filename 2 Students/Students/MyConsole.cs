using System;

namespace Students
{
    /// <summary>
    /// Basic console IO wrapper
    /// </summary>
    public class MyConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }
    }
}
