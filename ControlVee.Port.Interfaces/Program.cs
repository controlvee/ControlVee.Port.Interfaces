using System;

namespace ControlVee.Port.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream f;
            Stream f2;
            Stream m;

            f = new FileStream();
            m = new MemoryStream() { StreamSize = 10 };

            Console.WriteLine($"Executing: {f.Read()} Size: {m.StreamSize}");

            IStream i;
            FileStreamA fs;

            i = fs = new FileStreamA();

            //
            // FileStream class's implementation of
            // ToString() passed through IStream interface.
            //

            Console.WriteLine($"Action: {i} Size: {i.StreamSize}");
            Console.Read();
        }
    }

    interface IStream
    {
        public int StreamSize { get; set; }

        public string Read();

        public void Write(string data);
    }

    class FileStream : Stream
    {
        public string Copy(string newFile)
        {
            return $"Copying {newFile}.";
        }

        public void Write(string data)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Copy($"c:\\uers\\a\b\\test.txt")}";
        }
    }

    class FileStreamA : IStream
    {
        private int privateSize;

        int IStream.StreamSize { get { return privateSize; } set { privateSize = value; } }

        public string Read()
        {
            return "Data read from file.";
        }

        public string Copy(string newFile)
        {
            return $"Copying {newFile}.";
        }

        public void Write(string data)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Copy($"c:\\uers\\a\b\\test.txt")}";
        }
    }

    class Stream
    {
        public int StreamSize { get; set; }

        public virtual string Read()
        {
            return "Default data read.";
        }

        public override string ToString()
        {
            return $"Streamsize: {StreamSize} TypeName: {base.ToString()}";
        }
    }

    class MemoryStream : Stream
    {
        public override string Read()
        {
            return "Reading data from memory.";
        }

        public override string ToString()
        {
            return $"Reading data from memory stream.";
        }
    }
}
