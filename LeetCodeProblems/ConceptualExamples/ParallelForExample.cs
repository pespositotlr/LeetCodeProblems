using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeProblems.ConceptualExamples
{
    /// <summary>
    /// The Parallel.For method can be used to parallelize for-loops to run iterations concurrently:
    /// </summary>
    internal class ParallelForExample
    {
        static void ParallelForExampleMain()
        {
            int[] numbers = new int[1000];

            // Parallel.For to initialize the array in parallel
            Parallel.For(0, numbers.Length, i =>
            {
                numbers[i] = i * i;  // Example operation: square of the index
            });

            // Print the first few results
            Console.WriteLine("First 10 squares:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

    }

    //How it Works:
    //Parallel.For(start, end, body): This method runs the body of the loop in parallel, processing the iterations concurrently.
    //Each iteration can run on a separate thread, making it much faster when processing large numbers of iterations.

    //Benefits of Using Parallel Streams:
    //Performance: By leveraging multiple cores, parallel operations can often execute more quickly than sequential ones, especially for CPU-intensive operations.
    //Simplicity: Parallel LINQ (AsParallel()) and the Parallel class abstract away the complexity of manually managing threads.
    //Automatic Load Balancing: PLINQ and Parallel.For automatically divide work across available processors.

    //When Not to Use Parallel Streams:
    //I/O-bound tasks: For tasks like network requests or file I/O, parallelizing can actually decrease performance due to the overhead of context switching.
    //Small data sets: Parallelism introduces some overhead, so for small collections, it might not be beneficial.
    //Shared state: If your parallel operations involve shared state or resources that aren't properly synchronized, you could run into race conditions, leading to incorrect results or crashes.
}
