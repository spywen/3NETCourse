using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;

namespace Mmf
{
    public class MmfMain
    {
        private const string MmfName = "test";
        private const string MmfMutex = "testMutex";

        public static void ShareMemory()
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew(MmfName, 10000))
            {
                Console.WriteLine("Process A started.");
                bool mutexCreated;
                var mutex = new Mutex(true, MmfMutex, out mutexCreated);

                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    var writer = new BinaryWriter(stream);
                    writer.Write('a');
                }
                mutex.ReleaseMutex();

                Console.WriteLine("Please start process B. Once it's done press ENTER.");
                Console.ReadLine();

                mutex.WaitOne();
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    var reader = new BinaryReader(stream);
                    Console.WriteLine("Process A : {0}", reader.ReadChar());
                    Console.WriteLine("Process B : {0}", reader.ReadChar());
                    Console.ReadLine();
                }
                mutex.ReleaseMutex();
            }
        }
    }
}
