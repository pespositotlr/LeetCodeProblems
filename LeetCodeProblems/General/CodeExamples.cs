using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LeetCodeProblems.General
{
    public class CodeExamples
    {
        #region "Binary Search"
        // Binary Search
        // Assume a sorted array
        // Speed: O Log2n
        public static int BinarySearchIterative(int[] inputArray, int searchValue)
        {
            //Seed starting values
            int minIndex = 0;
            int maxIndex = inputArray.Length - 1;

            while (minIndex <= maxIndex)
            {
                //Divide and conquer using the middle-value between two items in the ordered array
                int midpointIndex = (minIndex + maxIndex) / 2;

                if (searchValue == inputArray[midpointIndex])
                {
                    return midpointIndex;
                }
                else if (searchValue < inputArray[midpointIndex])
                {
                    //Search value is less than the pivot value, so shift the max index to 1 lower than the midpoint
                    maxIndex = midpointIndex - 1;
                }
                else
                {
                    //Search value is less than the pivot value, so shift the min index to 1 higher than the midpoint
                    minIndex = midpointIndex + 1;
                }
            }
            return -1;
        }

        public static int BinarySearchRecursive(int[] inputArray, int searchValue)
        {
            //Seed starting values
            return BinarySearchRecursive(inputArray, searchValue, 0, inputArray.Length - 1);
        }

        public static int BinarySearchRecursive(int[] inputArray, int searchValue, int minIndex, int maxIndex)
        {
            if (minIndex > maxIndex)
            {
                //Item was not found
                return -1;
            }
            else
            {
                int midpointIndex = (minIndex + maxIndex) / 2;

                if (searchValue == inputArray[midpointIndex])
                {
                    return midpointIndex;
                }
                else if (searchValue < inputArray[midpointIndex])
                {
                    //Search value is less than the pivot value, so shift the max index to 1 lower than the midpoint
                    return BinarySearchRecursive(inputArray, searchValue, minIndex, midpointIndex - 1);
                }
                else
                {
                    //Search value is less than the pivot value, so shift the min index to 1 higher than the midpoint
                    return BinarySearchRecursive(inputArray, searchValue, midpointIndex + 1, maxIndex);
                }
            }
        }

        #endregion

        #region "Exception examples"
        //Exception examples
        public static int ArgumentOutOfRangeExceptionExample(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException e) when (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be negative.", e);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be greater than the array size.", e);
            }
        }
        public static void CustomLogExceptionExample()
        {
            try
            {
                string? s = null;
                Console.WriteLine(s.Length);
            }
            catch (Exception e) when (LogException(e))
            {
            }
            Console.WriteLine("Exception must have been handled");
        }

        private static bool LogException(Exception e)
        {
            Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
            Console.WriteLine($"\tMessage: {e.Message}");
            return false;
        }

        public static void ExampleInputProgram()
        {
            Console.Write("Please enter a number to divide 100: ");

            try
            {
                int num = int.Parse(Console.ReadLine());

                int result = 100 / num;

                Console.WriteLine("100 / {0} = {1}", num, result);
            }
            catch (DivideByZeroException ex)
            {
                Console.Write("Cannot divide by zero. Please try again.");
            }
            catch (InvalidOperationException ex)
            {
                Console.Write("Invalid operation. Please try again.");
            }
            catch (FormatException ex)
            {
                Console.Write("Not a valid format. Please try again.");
            }
            catch (Exception ex)
            {
                Console.Write("Error occurred! Please try again.");
            }
        }
        public static void ExampleFileInputException()
        {
            FileInfo file = null;
            StreamWriter sw = null;
            
            try
            {
                Console.Write("Enter a file name to write: ");
                string fileName = Console.ReadLine();
                file = new FileInfo(fileName);
                sw = file.AppendText();
                sw.WriteLine("Hello World!");
                sw.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: {0}", ex.Message);
            }
            finally
            {
                sw.Close();
                sw.Dispose();
                // Clean up resources
                file = null;
            }
        }

        public static void NestedTryCatchExample()
        {
            var divider = 0;

            try
            {
                try
                {
                    var result = 100 / divider;
                }
                catch
                {
                    Console.WriteLine("Inner catch");
                }
            }
            catch
            {
                Console.WriteLine("Outer catch");
            }
        }

        #endregion


        #region "Object Oriented Animals"
        // Generally speaking you shouldn't be implementing a function like "TrunkLength" unless all the children are meant to have a trunk
        // Type-checking to see if the current animal instance has a trunk is a code smell
        public abstract class Animal
        {
            public abstract string Color();
            public abstract double Weight();
            public abstract bool HasTrunk();
            public abstract double TrunkLength();
        }

        public class Zebra : Animal
        {
            public override string Color()
            {
                return "Black and white";
            }

            public override bool HasTrunk()
            {
                return false;
            }

            public override double TrunkLength()
            {
                return -1;
            }

            public override double Weight()
            {
                return 300.5;
            }
        }

        public class Elephant : Animal
        {
            public override string Color()
            {
                return "Grey";
            }

            public override bool HasTrunk()
            {
                return true;
            }

            public override double TrunkLength()
            {
                return 15;
            }

            public override double Weight()
            {
                return 3000.5;
            }
        }

        // A better way to implement the trunk concept would be something like this
        // You would use a Factory or some other pattern to determine which animal to instantiate and only pass the "TrunkedAnimal" object to appropriate places expecting it
        // Otherwise you could call "TrunkLength" despite it not having a real value to return
        public abstract class Animal2
        {
            public abstract string Color();
            public abstract double Weight();
            public abstract bool HasTrunk();
            public static Animal2 MakeAnimal(string type) //This is a pseudo-factory 
            {
                if (type == "Elephant")
                    return new Elephant2();
                else if(type == "Zebra")
                    return new Zebra2();

                return null;
            }
        }

        public abstract class TrunkedAnimal : Animal2
        {
            public abstract double TrunkLength();
        }


        public class Zebra2 : Animal2
        {
            public override string Color()
            {
                return "Black and white";
            }

            public override double Weight()
            {
                return 300.5;
            }
            public override bool HasTrunk()
            {
                return false;
            }
        }

        public class Elephant2 : TrunkedAnimal
        {
            public override string Color()
            {
                return "Grey";
            }

            public override bool HasTrunk()
            {
                return true;
            }

            // Only animals with trunks have this function
            public override double TrunkLength()
            {
                return 15;
            }

            public override double Weight()
            {
                return 3000.5;
            }
        }


        #endregion

    }
}
