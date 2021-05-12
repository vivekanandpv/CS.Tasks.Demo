using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var composedTask = GetTask();   //  beginning of async/await

            Console.WriteLine("Main thread continues");

            composedTask.Wait();   //  blocks here

            Console.WriteLine($"Main thread resumes after Wait()");
        }

        public static Task GetTask()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"First task completing... Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
