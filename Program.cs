using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Task returns value
            var t = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return 100;
            }); //  this assignment is non-blocking

            Console.WriteLine("Main thread continues...");

            t.Wait();  //  blocks till the task completes
            var i = t.Result;   //  result is immediately available after Wait();

            Console.WriteLine($"Main thread after t.Wait() and assignment to i: {i}");
        }
    }
}
