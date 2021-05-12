using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Tasks are higher abstractions. They represent the work we want to do.
            var task = Task.Run(() => Console.WriteLine("Hi there!"));
            Console.WriteLine("Main thread here");  //  Task is asynchronous

            //  we wait manually so that the result of the task is visible
            Thread.Sleep(1000);
        }
    }
}
