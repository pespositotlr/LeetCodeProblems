using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodeProblems.ConceptualExamples
{
    //The Monitor class in C# is used to synchronize access to a shared resource by multiple threads, similar to lock.
    //However, Monitor provides more flexibility, such as explicit wait and pulse signaling, which are not available with the lock keyword.

    //  Monitor.Enter(_lockObject): Acquires a lock on _lockObject, blocking other threads.
    //  Monitor.Exit(_lockObject): Releases the lock so other threads can proceed.
    //  Unlike lock, we must explicitly call Monitor.Exit() in a finally block to avoid deadlocks if an exception occurs.
    public class MonitorExample
    {
        private static readonly object _lockObject = new object();

        static void WorkerThread(int id)
        {
            Console.WriteLine($"Thread {id} is waiting to enter the critical section...");

            Monitor.Enter(_lockObject);
            try
            {
                Console.WriteLine($"Thread {id} has entered the critical section.");
                Thread.Sleep(2000); // Simulating work
                Console.WriteLine($"Thread {id} is leaving the critical section.");
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }
        }

        static void MonitorExampleMain()
        {
            for (int i = 1; i <= 3; i++)
            {
                Thread worker = new Thread(() => WorkerThread(i));
                worker.Start();
            }
        }

        /* Output
        Thread 1 is waiting to enter the critical section...
        Thread 1 has entered the critical section.
        Thread 2 is waiting to enter the critical section...
        Thread 3 is waiting to enter the critical section...
        Thread 1 is leaving the critical section.
        Thread 2 has entered the critical section.
        Thread 2 is leaving the critical section.
        Thread 3 has entered the critical section.
        Thread 3 is leaving the critical section.
         */


        //Using Monitor.Wait() and Monitor.Pulse() for Thread Signaling
        //This example shows producer-consumer synchronization, where one thread produces data, and another thread waits until data is available.
        private static readonly object _lockObject2 = new object();
        private static bool _isDataAvailable = false;

        static void Producer()
        {
            Thread.Sleep(2000); // Simulate data production time
            lock (_lockObject2)
            {
                Console.WriteLine("Producer: Data is ready.");
                _isDataAvailable = true;
                Monitor.Pulse(_lockObject2); // Signal the waiting consumer thread
            }
        }

        static void Consumer()
        {
            lock (_lockObject2)
            {
                while (!_isDataAvailable)
                {
                    Console.WriteLine("Consumer: Waiting for data...");
                    Monitor.Wait(_lockObject2); // Wait until data is available
                }
                Console.WriteLine("Consumer: Data consumed.");
            }
        }

        static void MonitorExampleMain2()
        {
            Thread consumerThread = new Thread(Consumer);
            Thread producerThread = new Thread(Producer);

            consumerThread.Start();
            producerThread.Start();

            consumerThread.Join();
            producerThread.Join();
        }
    }
}
