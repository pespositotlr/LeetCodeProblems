using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.ConceptualExamples
{
    // pass custom data with an event, use EventHandler<T>.
    internal class EvenHandlerExample23
    {
    }

    // 1. Define custom EventArgs to hold event data
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; }
        public MessageEventArgs(string message) => Message = message;
    }

    public class EvenHandlerExample3Publisher
    {
        // 2. Declare the event using EventHandler<T>
        public event EventHandler<MessageEventArgs> Notify;

        public void DoSomething()
        {
            Console.WriteLine("Task started...");

            // 3. Raise the event with custom data
            Notify?.Invoke(this, new MessageEventArgs("Task completed successfully!"));
        }
    }

    public class EvenHandlerExample3Subscriber
    {
        public void OnNotify(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"Subscriber received: {e.Message}");
        }
    }

    class EvenHandlerExample3Program
    {
        static void EvenHandlerExample23Main()
        {
            EvenHandlerExample3Publisher pub = new EvenHandlerExample3Publisher();
            EvenHandlerExample3Subscriber sub = new EvenHandlerExample3Subscriber();

            // 4. Subscribe to the event
            pub.Notify += sub.OnNotify;

            pub.DoSomething(); // Trigger event
        }
    }
}
