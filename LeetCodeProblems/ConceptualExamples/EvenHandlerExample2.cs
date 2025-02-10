using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.ConceptualExamples
{
    internal class EvenHandlerExample2
    {
    }

    //Instead of defining a custom delegate, you can use the built-in EventHandler or EventHandler<T>.
    public class EvenHandlerExample2Publisher
    {
        // 1. Declare the event using EventHandler
        public event EventHandler Notify;

        public void DoSomething()
        {
            Console.WriteLine("Task started...");

            // 2. Raise the event
            Notify?.Invoke(this, EventArgs.Empty);
        }
    }

    public class EvenHandlerExample2Subscriber
    {
        public void OnNotify(object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber received notification.");
        }
    }

    class EvenHandlerExample2Program
    {
        public static void EvenHandlerExample2ProgramMain()
        {
            EvenHandlerExample2Publisher pub = new EvenHandlerExample2Publisher();
            EvenHandlerExample2Subscriber sub = new EvenHandlerExample2Subscriber();

            // 3. Subscribe to the event
            pub.Notify += sub.OnNotify;

            pub.DoSomething(); // Trigger event
        }
    }
}
