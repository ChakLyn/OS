using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.Diagnostics;

namespace ConsoleLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("testmap", 10000))
            {
                bool mutexCreated;
                Mutex mutex = new Mutex(true, "testmapmutex", out mutexCreated);

                byte[] life = new byte[100];

                for (int i = 0; i < 100; i++)
                {
                        life[i] = 0;
                }

                life[54] = 1;
                life[55] = 1;
                life[56] = 1;

                Process myProcessB = new Process();
                Process[] myProcessC = new Process[10];

                for (int i = 0; i < myProcessC.Length; i++)
                    myProcessC[i] = new Process();

                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    for (int i = 0; i < 100; i++)
                    {
                        writer.Write(life[i]);
                    }
                }
                mutex.ReleaseMutex();

                Console.WriteLine("To start processes press ENTER.");
                Console.ReadLine();
                try
                {
                    myProcessB.StartInfo.FileName = "ConsoleLab4B";
                    myProcessB.Start();                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                foreach(Process p in myProcessC)
                try
                {
                    p.StartInfo.FileName = "ConsoleLab4C";
                    p.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }
        }
    }
}
