using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;

namespace _3NETB
{
    class Program
    {
        private const string MmfName = "test";
        private const string MmfMutex = "testMutex";

        static void Main(string[] args)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MmfName))
                {
                    var mutex = Mutex.OpenExisting(MmfMutex);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        var writer = new BinaryWriter(stream);
                        writer.Write('b');
                    }
                    mutex.ReleaseMutex();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Memory Mapped File does not exist. Please run process A before");
                Console.ReadLine();
            }
            
        }
    }
}
