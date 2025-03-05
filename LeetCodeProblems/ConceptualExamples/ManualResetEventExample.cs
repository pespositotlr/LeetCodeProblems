using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodeProblems.ConceptualExamples
{
    internal class ManualResetEventExample
    {
        static ManualResetEvent manualEvent = new ManualResetEvent(false); // Initially blocked

        static void WorkerThread(int id)
        {
            Console.WriteLine($"Thread {id} waiting...");
            manualEvent.WaitOne(); // Wait until signaled
            Console.WriteLine($"Thread {id} proceeding...");
        }

        static void Main()
        {
            for (int i = 1; i <= 3; i++)
            {
                Thread worker = new Thread(() => WorkerThread(i));
                worker.Start();
            }

            Thread.Sleep(2000); // Simulate work in main thread
            Console.WriteLine("Main thread signaling all worker threads.");
            manualEvent.Set(); // Unblock all waiting threads

            Thread.Sleep(2000); // Allow threads to process
            Console.WriteLine("Resetting event. New threads will wait.");
            manualEvent.Reset(); // Reset event to block future threads

            Thread newWorker = new Thread(() => WorkerThread(4));
            newWorker.Start();
        }

        /* Output
        Thread 1 waiting...
        Thread 2 waiting...
        Thread 3 waiting...
        Main thread signaling all worker threads.
        Thread 1 proceeding...
        Thread 2 proceeding...
        Thread 3 proceeding...
        Resetting event. New threads will wait.
        Thread 4 waiting...
         */
    }
}
