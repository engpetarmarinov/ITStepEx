using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set the name of the main thread
            SetCurrentThreadName("Main");
            //Measure the elapsed time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //The method is called synchronously
            StartWorking();

            Console.WriteLine("Thread name: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Time elapsed: {0} secs", stopwatch.Elapsed.TotalSeconds);
        }

        private static void SetCurrentThreadName(string name)
        {
            if (Thread.CurrentThread.Name == null) {
                Thread.CurrentThread.Name = name;
            }
        }

        public static void StartWorking()
        {
            //async worker will be executed in 3 secs
            var worker1 = Worker1();
            //async worker will be executed in 5 secs
            var worker2 = Worker2();
            //blocks the main Dispatcher thread (Main thread in this case) and wait for all tasks
            Task.WaitAll(worker1, worker2);
        }

        private static async Task Worker1()
        {            
            var result = await CalculateAsync();
            //continuation block of code after await
            Console.WriteLine("Thread name: {0}", Thread.CurrentThread.Name);
            Console.WriteLine(result);
        }
        
        private static async Task Worker2()
        {
            
            await Task.Run(() =>
            {
                SetCurrentThreadName("Worker2");
                //This will be executed in the Task worker thread
                Thread.Sleep(2000);
                Console.WriteLine("Thread name: {0}", Thread.CurrentThread.Name);
                Console.WriteLine("work 2");
            });
            //continuation block of code after await
            Thread.Sleep(3000);
            Console.WriteLine("Thread name: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("work 2 second line");
        }
        
        private static async Task<string> CalculateAsync()
        {
            var result = await Task<int>.Run(() => {
                SetCurrentThreadName("Worker1");
                Thread.Sleep(2000);
                return "Work 1";
            });
            //continuation block of code after await
            Thread.Sleep(1000);
            Console.WriteLine("Thread name: {0}",Thread.CurrentThread.Name);
            Console.WriteLine("work 1 second line");
            return result;
        }
    }
}
