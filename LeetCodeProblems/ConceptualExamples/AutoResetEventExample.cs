using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodeProblems.ConceptualExamples
{
    //https://learn.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=net-9.0
    //These are used for Thread Synchronization, rather than Broadcasting Events which ManualResetEvents do
    //This also only releases one thread at a time, as opposed to ManualResetEvents which do all at once
    public class AutoResetEventExample
    {

        private static AutoResetEvent event_1 = new AutoResetEvent(true);
        private static AutoResetEvent event_2 = new AutoResetEvent(false);

        static void AutoResetEventExampleMain()
        {
            Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
                              "The threads wait on AutoResetEvent #1, which was created\r\n" +
                              "in the signaled state, so the first thread is released.\r\n" +
                              "This puts AutoResetEvent #1 into the unsignaled state.");
            Console.ReadLine();

            for (int i = 1; i < 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }
            Thread.Sleep(250);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Press Enter to release another thread.");
                Console.ReadLine(); //User presses enter
                event_1.Set(); //Allows thread to continue
                Thread.Sleep(250); //Simulates work
            }

            Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Press Enter to release a thread.");
                Console.ReadLine(); //User presses enter
                event_2.Set(); //Allows thread to continue
                Thread.Sleep(250); //Simulates work
            }

            Console.ReadLine();
        }

        static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
            event_1.WaitOne(); //Wait until signaled
            Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

            Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
            event_2.WaitOne();  //Wait until signaled
            Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

            Console.WriteLine("{0} ends.", name);
        }

        /* This example produces output similar to the following:

        Press Enter to create three threads and start them.
        The threads wait on AutoResetEvent #1, which was created
        in the signaled state, so the first thread is released.
        This puts AutoResetEvent #1 into the unsignaled state.

        Thread_1 waits on AutoResetEvent #1.
        Thread_1 is released from AutoResetEvent #1.
        Thread_1 waits on AutoResetEvent #2.
        Thread_3 waits on AutoResetEvent #1.
        Thread_2 waits on AutoResetEvent #1.
        Press Enter to release another thread.

        Thread_3 is released from AutoResetEvent #1.
        Thread_3 waits on AutoResetEvent #2.
        Press Enter to release another thread.

        Thread_2 is released from AutoResetEvent #1.
        Thread_2 waits on AutoResetEvent #2.

        All threads are now waiting on AutoResetEvent #2.
        Press Enter to release a thread.

        Thread_2 is released from AutoResetEvent #2.
        Thread_2 ends.
        Press Enter to release a thread.

        Thread_1 is released from AutoResetEvent #2.
        Thread_1 ends.
        Press Enter to release a thread.

        Thread_3 is released from AutoResetEvent #2.
        Thread_3 ends.
         */


        //Simpler example
        static AutoResetEvent autoEvent = new AutoResetEvent(false);

        static void WorkerThread()
        {
            Console.WriteLine("Worker thread waiting...");
            autoEvent.WaitOne(); // Wait until signaled
            Console.WriteLine("Worker thread proceeding...");
        }

        static void AutoResetEventExampleMain2()
        {
            Thread worker = new Thread(WorkerThread);
            worker.Start();

            Thread.Sleep(2000); // Simulate work in main thread
            Console.WriteLine("Main thread signaling worker thread.");
            autoEvent.Set(); // Signal the worker thread to proceed

            worker.Join(); //Blocks calling thread until worker thread terminates
        }

        /* Output:
            Worker thread waiting...
            Main thread signaling worker thread.
            Worker thread proceeding...
        */

        //Auto-Resets to false after releasing a waiting thread.
        //Only one thread gets signaled per Set() call.
        //Blocks new threads if not signaled again.
        //Good for producer-consumer scenarios where controlled access is required.
    }

}
