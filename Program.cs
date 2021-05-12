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

            var result = composedTask.Result;   //  blocks here

            Console.WriteLine($"Main thread resumes after blocking; result: {result}");
        }

        public static Task<int> GetTask()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"First task completing... Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                return 2;
            }).ContinueWith((t) =>
            {
                Thread.Sleep(1000);
                var i = t.Result;
                Console.WriteLine($"Second task completing... Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                return i * i;
            }).ContinueWith((u) =>
            {
                Thread.Sleep(1000);
                var j = u.Result;
                Console.WriteLine($"Third task completing... Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                return j * j;
            });
        }
    }
}
