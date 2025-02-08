using Microsoft.Office.Interop.Excel;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeProblems.ConceptualExamples
{
    // In C#, a Parallel Stream refers to the ability to process sequences of data (such as collections or arrays) in parallel,
    // which can potentially improve performance on multi-core processors by utilizing multiple threads for processing.

    // Parallel streams in C# are typically implemented using the Parallel LINQ (PLINQ) library or the Parallel class.
    // These allow operations that would traditionally be done sequentially to be run in parallel across multiple processors, making use of multiple threads to perform tasks concurrently.
    internal class PLINQExample
    {
        //PLINQ(Parallel LINQ) : PLINQ extends LINQ by adding parallel processing capabilities to LINQ queries.
        //With PLINQ, LINQ queries can be automatically divided into chunks and executed concurrently on multiple threads.
        //Parallel Class: The Parallel class in the System.Threading.Tasks namespace provides a way to parallelize the execution of loops or blocks of code.
        public static void PLINQMain()
        {
        // A large collection of numbers
            var numbers = Enumerable.Range(1, 1000000).ToArray();

        // Using PLINQ to perform a parallel query
            var parallelQuery = numbers.AsParallel()
                                       .Where(x => x % 2 == 0)
                                       .Select(x => x * 2)
                                       .ToArray();

            // Display a few results
            Console.WriteLine($"First 10 results: {string.Join(", ", parallelQuery.Take(10))}");

        }

        //How it Works:
        //AsParallel() : Converts the sequence into a parallel sequence.
        //The query then performs filtering(Where) and transformation(Select) in parallel.
        //PLINQ will divide the work into parts and process them concurrently.

        static void PLINQExceptionMain()
        {
            var numbers = new[] { 1, 2, 0, 4, 5 };

            try
            {
                var result = numbers.AsParallel()
                                    .Select(x => 10 / x)  // Will throw divide-by-zero error
                                    .ToArray();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("An error occurred during parallel execution:");
                foreach (var innerEx in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(innerEx.Message);
                }

                //AggregateException is used to aggregate exceptions thrown during parallel execution.
                //You need to handle potential exceptions, especially for operations like division by zero, which might be common in parallel queries.
            }
        }
    }
}
