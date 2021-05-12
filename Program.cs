using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //  this Task doesn't return
            var t = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Good morning");
            }); //  this assignment is non-blocking

            Console.WriteLine("Main thread continues...");

            t.Wait();  //  blocks till the task completes

            Console.WriteLine($"Main thread after t.Wait()");
        }
    }
}
