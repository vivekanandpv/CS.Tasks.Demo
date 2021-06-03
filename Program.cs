using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Tasks.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Please read: https://stackoverflow.com/a/1560567
            var source = new CancellationTokenSource();
            var token = source.Token;

            var task = Task.Run(() => {
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        //...
                        Console.WriteLine("Breaking early...");
                        return;
                    }

                    Thread.Sleep(1000);
                    Console.WriteLine($"Loop {i}");
                }

                Console.WriteLine("Normal exit");
            }, token);

            Thread.Sleep(2000);
            source.Cancel();

            Thread.Sleep(5000);
        }
    }
}
