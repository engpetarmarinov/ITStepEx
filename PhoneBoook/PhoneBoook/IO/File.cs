using System.IO;
using System;

namespace PhoneBoook.IO
{
    public class File : IReader, IWritter, IDisposable
    {
        private readonly string _readPath;
        private string _writerPath;
        protected readonly StreamReader FsReader;
        protected StreamWriter FsWriter;

        public File(string readPath = null, string writePath = null)
        {
            _readPath = readPath;
            if (readPath != null && !System.IO.File.Exists(readPath))
            {
                throw new FileNotFoundException($"The readPath {readPath} could not be found.");
            }
            // Open a stream reader in order to read line by line.
            if (readPath != null)
            {
                FsReader = new StreamReader(readPath);
            }
            //Set a strean writer
            if (writePath != null)
            {
                SetFileWriter(writePath);
            }
        }

        public string Read()
        {
            return System.IO.File.ReadAllText(_readPath);
        }

        public string ReadLine()
        {
            return FsReader.ReadLine();
        }

        public void Write(string text)
        {
            FsWriter.Write(text);
        }

        public void WriteLine(string line)
        {
            FsWriter.WriteLine(line);
        }

        public void SetFileWriter(string path)
        {
            if (FsWriter != null && path == _writerPath) return;
            _writerPath = path;
            FsWriter = new StreamWriter(path);
            FsWriter.AutoFlush = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (!disposing) return;
            FsReader?.Close();
            FsWriter?.Close();
        }

        ~File()
        {
            Dispose(false);
        }

    }
}
