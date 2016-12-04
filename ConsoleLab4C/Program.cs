using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;

namespace ConsoleLab4C
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("testmap"))
                {

                    Mutex mutex = Mutex.OpenExisting("testmapmutex");
                    while (true)
                    {
                        Random rnd = new Random();
                        mutex.WaitOne();
                        using (MemoryMappedViewStream stream = mmf.CreateViewStream((byte)rnd.Next(0,100),0))
                        {
                            BinaryWriter writer = new BinaryWriter(stream);
                            writer.Write(1);
                            Console.WriteLine("I am writing!");
                        }
                        Thread.Sleep(new Random().Next(1,4)*100);
                        mutex.ReleaseMutex();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first, then B.");
            }
        }
    }
}
