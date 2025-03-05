using System;

namespace LeetCodeProblems.ConceptualExamples
{
    //Tail Recursion in C#
    //Tail recursion is a special type of recursion where the recursive call is the last operation performed before returning the result.
    //This allows some compilers and runtimes to optimize recursion by reusing the current function stack frame instead of creating a new one, reducing memory consumption.
    internal class TailRecursionExample
    {
        static void TailRecursionExample_Main()
        {
            int number = 5;
            long result = FactorialTailRecursive(number, 1);
            Console.WriteLine($"Factorial of {number} is {result}");
        }

        // Tail Recursive Factorial
        static long FactorialTailRecursive(int n, long accumulator)
        {
            if (n == 0 || n == 1)
                return accumulator;

            return FactorialTailRecursive(n - 1, n * accumulator);
        }

        //How It Works

        //The accumulator keeps track of the computed value.
        //The recursive call is the last operation, which qualifies it as tail-recursive.
        //Instead of building up a large call stack, the function passes the updated value down.


        //Example: Tail Recursive Fibonacci
        //The Fibonacci sequence is commonly solved using normal recursion, leading to redundant calculations.
        //Tail recursion avoids this:
        static void FibonacciTailRecursive_Main()
        {
            int n = 10;
            long result = FibonacciTailRecursive(n, 0, 1);
            Console.WriteLine($"Fibonacci({n}) = {result}");
        }

        // Tail Recursive Fibonacci
        static long FibonacciTailRecursive(int n, long a, long b)
        {
            if (n == 0) return a;
            if (n == 1) return b;

            return FibonacciTailRecursive(n - 1, b, a + b);
        }

        //Why Use Tail Recursion?

        //✔ Optimized stack usage – avoids stack overflow issues.
        //✔ Better performance – can be optimized by compilers that support Tail Call Optimization (TCO).
        //✔ Eliminates redundant calculations, especially for problems like Fibonacci.

        //However, .NET does not currently perform Tail Call Optimization (TCO) in JIT compilation, so while this approach is structurally better, it does not provide direct performance gains in .NET.
    }
}
