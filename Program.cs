using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Task can return
            var t = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return 100;
            }); //  this assignment is non-blocking

            Console.WriteLine("Main thread continues...");

            var result = t.Result;  //  blocks

            Console.WriteLine($"Main thread after t.Result...{result}");
        }
    }
}
