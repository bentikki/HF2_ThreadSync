using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync_Opgave1
{
    class Program
    {
        //Lock object.
        static object _lock = new object();
        static int counter;

        //Opgave 1
        static void Main(string[] args)
        {
            //Creates 2 new threads.
            new Thread(Incrementer).Start();
            new Thread(Decrementer).Start();
        }

        static void Incrementer()
        {
            //Moniters Lock object
            Monitor.Enter(_lock);
            try
            {
                //Increments count by 2
                counter = counter + 2;
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] - has increased counter to {counter}");

                //Waits 1 sec.
                Thread.Sleep(1000);
            }
            finally
            {
                //Releases Lock object
                Monitor.Exit(_lock);
            }
            
        }

        static void Decrementer()
        {
            //Moniters Lock object
            Monitor.Enter(_lock);
            try
            {
                //Decreases count by 1
                counter--;
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] - has decreased counter to {counter}");

                //Waits 1 sec.
                Thread.Sleep(1000);
            }
            finally
            {
                //Releases Lock object
                Monitor.Exit(_lock);
            }
            
        }
    }
}
