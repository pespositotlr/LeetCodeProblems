/* Problem Name is &&& SubArray Exceeding Sum &&& PLEASE DO NOT REMOVE THIS LINE. */

/*
 Instructions to candidate.
  1) Your task is ultimately to implement a function that takes in an array of non-negative numbers and an integer.
     You want to return the *LENGTH* of the shortest subarray whose sum is at least the integer,
     and -1 if no such sum exists.
  2) Run this code in the REPL to observe its behaviour. The
     execution entry point is main().
  3) Consider adding some additional tests in doTestsPass().
  4) Implement SubArrayExceedsSum() correctly.
  5) If time permits, some possible follow-ups.
*/

using System;
using System.Linq;

public class Solution
{
    public static int SubArrayExceedsSum(int[] arr, int target)
    {

        target.GetHashCode();
        if (arr.Length == 0) return -1;

        int currentTotal = 0;

        arr = arr.OrderByDescending(x => x).ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            currentTotal += arr[i];

            Console.WriteLine("CurrentTotal: ");
            Console.WriteLine(currentTotal);


            Console.WriteLine("CurrentNumberOfDigits: ");
            Console.WriteLine(i + 1);
            Console.WriteLine("========");

            if (currentTotal >= target)
            {
                return i + 1;
            }


        }

        return -1;
    }

    /**
    * int DoTestsPass()
    * Returns 1 if all tests pass. Otherwise returns 0.
    */
    public static bool DoTestsPass()
    {
        int[] arr = { 1, 2, 3, 4 };

        bool result = true;
        result = result && SubArrayExceedsSum(arr, 6) == 2;
        result = result && SubArrayExceedsSum(arr, 5) == 2;
        result = result && SubArrayExceedsSum(arr, 12) == -1;
        result = result && SubArrayExceedsSum(arr, 10) == 4;

        int[] arr2 = { 9, 2, 17, 3 };
        result = result && SubArrayExceedsSum(arr2, 30) == 4;
        result = result && SubArrayExceedsSum(arr2, 16) == 1;
        result = result && SubArrayExceedsSum(arr2, 18) == 2;
        result = result && SubArrayExceedsSum(arr2, 55) == -1;

        return result;
    }

    /**
    * Execution entry point.
    */
    public static void SubArrayExceedsSum_Main(String[] args)
    {
        if (DoTestsPass())
        {
            Console.WriteLine("All tests pass.");
        }
        else
        {
            Console.WriteLine("There are test failures.");
        }
    }

}
