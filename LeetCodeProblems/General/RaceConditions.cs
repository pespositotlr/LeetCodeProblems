using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://www.csharpstar.com/csharp-race-conditions-in-threading/
    /// A data race or race condition is a problem that can occur when a multithreaded program is not properly synchronized.
    /// If two or more threads access the same memory without synchronization, the data race occurs.
    /// </summary>
    class RaceConditions
    {
        //Using Thread
        class Program1
        {
            private static int counter;
            static void Main1(string[] args)
            {
                Thread T1 = new Thread(PrintStar);
                T1.Start();

                Thread T2 = new Thread(PrintPlus);
                T2.Start();

                Console.ReadLine();
            }
            static void PrintStar()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" * " + "\t");
                }
            }

            private static void PrintPlus()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" + " + "\t");
                }
            }
        }

        //Using TPL
        class Program2
        {
            private static int counter;
            static void Main2(string[] args)
            {
                Task.Factory.StartNew(PrintStar);
                Task.Factory.StartNew(PrintPlus);
                Console.ReadLine();
            }
            static void PrintStar()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" * " + "\t");
                }
            }

            private static void PrintPlus()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" + " + "\t");
                }
            }
        }

        /// <summary>
        /// Synchronization using Thread.Join()
        /// Thread.Join method blocks the calling thread until the executing thread terminates.
        /// In the program below we have executed Thread1.Join method before the declaration of thread2, 
        /// which ensures that delegate associated with thread1 get executes first before thread2 starts.In this case we always gets consistent output and eliminates race condition.
        /// </summary>
        class Program3
        {
            private static int counter;
            static void Main3(string[] args)
            {
                var T1 = new Thread(PrintStar);
                T1.Start();
                T1.Join();

                var T2 = new Thread(PrintPlus);
                T2.Start();
                T2.Join();

                // main thread will always execute after T1 and T2 completes its execution
                Console.WriteLine("Ending main thread");
                Console.ReadLine();
            }
            static void PrintStar()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" * " + "\t");
                }
            }

            private static void PrintPlus()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" + " + "\t");
                }
            }
        }

        /// <summary>
        /// 2. Synchronization using Task.ContinueWith
        /// TPL continue method is useful to start a task after another one completes its execution.
        /// </summary>
        class Program4
        {
            private static int counter;
            static void Main4(string[] args)
            {
                Task T1 = Task.Factory.StartNew(PrintStar);
                Task T2 = T1.ContinueWith(antacedent => PrintPlus());

                Task.WaitAll(new Task[] { T1, T2 });

                Console.WriteLine("Ending main thread");
            }
            static void PrintStar()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" * " + "\t");
                }
            }

            private static void PrintPlus()
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" + " + "\t");
                }
            }
        }

        /// 3. Synchronization using Lock
        /// Using Lock statement you can ensure only one thread can be executed at any point of time.
        class Program5
        {
            static object locker = new object();
            private static int counter;
            static void Main5(string[] args)
            {
                new Thread(PrintStar).Start();
                new Thread(PrintPlus).Start();
            }

            static void PrintStar()
            {
                lock (locker) // Thread safe code
                {
                    for (counter = 0; counter < 5; counter++)
                    {
                        Console.Write(" * " + "\t");
                    }
                }
            }

            static void PrintPlus()
            {
                lock (locker) // Thread safe code
                {
                    for (counter = 0; counter < 5; counter++)
                    {
                        Console.Write(" + " + "\t");
                    }
                }
            }
        }

        /// <summary>
        /// 4. Synchronization using Monitor Enter – Monitor Exit
        /// This works exactly like Lock statement.
        /// </summary>
        class Program6
        {
            static object locker = new object();
            private static int counter;

            static void Main6(string[] args)
            {
                new Thread(PrintStar).Start();
                new Thread(PrintPlus).Start();
            }

            static void PrintStar()
            {
                Monitor.Enter(locker);
                try
                {
                    for (counter = 0; counter < 5; counter++)
                    {
                        Console.Write(" + " + "\t");
                    }
                }
                finally
                {
                    Monitor.Exit(locker);
                }
            }

            static void PrintPlus()
            {
                Monitor.Enter(locker);
                try
                {
                    for (counter = 0; counter < 5; counter++)
                    {
                        Console.Write(" - " + "\t");
                    }
                }
                finally
                {
                    Monitor.Exit(locker);
                }
            }
        }
    }
}