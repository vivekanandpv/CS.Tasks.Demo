using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        //  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.1/async-main
        static async Task Main(string[] args)
        {

            var result = await GetThirdTaskAsync();   //  blocked

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
