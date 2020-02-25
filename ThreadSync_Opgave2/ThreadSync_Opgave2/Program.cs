using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync_Opgave2
{
    class Program
    {
        static object _lock = new object();
        static int counter;

        static void Main(string[] args)
        {
            new Thread(StarThread).Start();
            new Thread(HashtagThread).Start();

        }
    
        static void StarThread()
        {
            lock (_lock)
            {
                while (counter < 1000)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write("*");
                        counter++;
                    }
                    Console.Write(" " + counter);
                    Console.WriteLine();
                    Thread.Sleep(500);
                }
            }

        }

        static void HashtagThread()
        {
            
            lock (_lock)
            {
                while (counter < 1000)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write("#");
                        counter++;
                    }
                    Console.Write(" " + counter);
                    Console.WriteLine();
                    Thread.Sleep(500);
                }
            }
        }


    }
}
