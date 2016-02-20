using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_15.Threads_and_Locks
{
    [TestClass]
    public class Ch15Q07
    {
        [TestMethod]
        public void TestCh15Q07()
        {

        }

        public static void Main()
        {
            Console.Out.WriteLine("Running main");
            
            var gn = new Thread(GenerateNumbersClass.GenerateNumbers);
            gn.Start();

            
            new Thread(PrintFizzBuzz).Start();
            new Thread(PrintFizz).Start();
            new Thread(PrintBuzz).Start();
            new Thread(PrintNumber).Start();

            
            Console.ReadKey();
        }

        internal static readonly ConcurrentQueue<int> FizzBuzzInputQueue = new ConcurrentQueue<int>();
        private static readonly ConcurrentQueue<int> FizzInputQueue = new ConcurrentQueue<int>();
        private static readonly ConcurrentQueue<int> BuzzInputQueue = new ConcurrentQueue<int>();
        private static readonly ConcurrentQueue<int> NumberInputQueue = new ConcurrentQueue<int>();

        public static readonly Semaphore Sem1 = new Semaphore(1, 1);
        public static readonly Semaphore Sem2 = new Semaphore(0, 1);
        public static readonly Semaphore Sem3 = new Semaphore(0, 1);
        public static readonly Semaphore Sem4 = new Semaphore(0, 1);

        private static void PrintFizzBuzz()
        {
            while (true)
            {
                int currentNumber;
                if (FizzBuzzInputQueue.TryDequeue(out currentNumber))
                {
                    Sem1.WaitOne();
                    if (currentNumber % 3 == 0 && currentNumber % 5 == 0)
                        Console.Out.WriteLine("FizzBuzz");
                    else
                        FizzInputQueue.Enqueue(currentNumber);
                    Sem2.Release();
                }
            }
        }

        private static void PrintFizz()
        {
            while (true)
            {
                Sem2.WaitOne();
                int currentNumber;
                if (FizzInputQueue.TryDequeue(out currentNumber))
                {                    
                    if (currentNumber % 3 == 0)
                        Console.Out.WriteLine("Fizz");
                    else
                        BuzzInputQueue.Enqueue(currentNumber);                    
                }
                Sem3.Release();
            }
        }

        private static void PrintBuzz()
        {
            while (true)
            {
                Sem3.WaitOne();
                int currentNumber;
                if (BuzzInputQueue.TryDequeue(out currentNumber))
                {
                    if (currentNumber % 5 == 0)
                        Console.Out.WriteLine("Buzz");
                    else
                        NumberInputQueue.Enqueue(currentNumber);
                    
                }
                Sem4.Release();
            }
        }

        private static void PrintNumber()
        {
            while (true)
            {
                Sem4.WaitOne();
                int currentNumber;
                if (NumberInputQueue.TryDequeue(out currentNumber))
                {
                    Console.Out.WriteLine(currentNumber);
                    
                }
                Sem1.Release();
            }
        }
    }

    class GenerateNumbersClass
    {
        internal static void GenerateNumbers()
        {
            int currentNumber = 1;

            while (!Stop)
            {
                if (currentNumber == 1000)
                    Stop = true;
                Ch15Q07.FizzBuzzInputQueue.Enqueue(currentNumber++);

            }
        }

        public static bool Stop { get; set; }
    }
}
