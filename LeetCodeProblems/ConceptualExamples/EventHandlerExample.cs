using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.ConceptualExamples
{
    internal class EventHandlerExample
    {
    }

    public class Publisher
    {
        // 1. Declare the delegate (defines the signature of event handlers)
        public delegate void NotifyEventHandler(string message);

        // 2. Declare the event using the delegate
        public event NotifyEventHandler Notify;

        public void DoSomething()
        {
            Console.WriteLine("Task started...");

            // 3. Raise the event (invoke event handlers)
            Notify?.Invoke("Task is complete!");
        }
    }

    public class Subscriber
    {
        public void OnNotify(string message)
        {
            Console.WriteLine($"Subscriber received notification: {message}");
        }
    }

    class Program
    {
        static void EventHandlerExampleMain()
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();

            // 4. Subscribe to the event
            pub.Notify += sub.OnNotify;

            pub.DoSomething(); // Trigger event

            // 5. Unsubscribe (optional)
            pub.Notify -= sub.OnNotify;
        }
    }
}
