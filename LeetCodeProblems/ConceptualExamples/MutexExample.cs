using RestSharp.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace LeetCodeProblems.ConceptualExamples
{
    //Explanation:

    //A Mutex object is created to ensure exclusive access to the critical section.
    //Five threads are started, each attempting to enter the critical section.
    //mutex.WaitOne() is called to acquire the mutex before accessing the resource.
    //The thread simulates work by sleeping for 2 seconds.
    //mutex.ReleaseMutex() is called to release the mutex, allowing another thread to enter.
    internal class MutexExample
    {
        // Create a Mutex instance
        private static Mutex mutex = new Mutex();

        static void MutexExampleMain()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(AccessResource);
                thread.Name = "Thread " + i;
                thread.Start();
            }
        }

        static void AccessResource()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting to enter the critical section...");

            mutex.WaitOne(); // Acquire the mutex

            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the critical section.");
            Thread.Sleep(2000); // Simulate some work
            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the critical section.");

            mutex.ReleaseMutex(); // Release the mutex
        }
    }

}
