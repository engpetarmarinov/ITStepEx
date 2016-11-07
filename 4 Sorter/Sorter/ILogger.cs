namespace Sorter
{
    public interface ILogger
    {
        void Write(string str);
        void WriteLine(string str);
        string ReadLine();
    }
}