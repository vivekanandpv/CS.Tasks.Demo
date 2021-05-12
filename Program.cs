using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        //  for C# 5, 6, 7
        static void Main(string[] args)
        {

            //  also consider the shorthand:
            //  var result = GetThirdTaskAsync().Result;
            var awaiter = GetThirdTaskAsync().GetAwaiter(); //  non-blocking

            Console.WriteLine("Main thread continues");

            var result = awaiter.GetResult();   //  blocked

            Console.WriteLine($"Main thread resumes after blocking; result: {result}");
        }

        public static async Task<int> GetThirdTaskAsync()
        {
            var resultFromFirst = await GetSecondTaskAsync();
            return resultFromFirst * resultFromFirst;
        }

        public static async Task<int> GetSecondTaskAsync()
        {
            var resultFromFirst = await GetFirstTaskAsync();
            return resultFromFirst * resultFromFirst;
        }


        public static Task<int> GetFirstTaskAsync()
        {
            //  This method returns Task<TResult>
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"First task completing... Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                return 2;
            });
        }
    }
}
