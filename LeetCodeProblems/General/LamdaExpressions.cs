using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://www.csharpstar.com/lambda-expression-in-csharp6/
    /// ” A Lambda Expression is an unnamed method written in place of a delegate instance.”
    ///    The compiler immediately converts the Lambda expression to:
    ///       A delegate instance
    ///       An expression tree
    ///   The Lambda expression may have 2 characteristics.
    ///        Parameter lists may have an explicit or implicit types
    ///        Bodies may be expressions or statement blocks
    ///        
    //  (Parameters) => expression or statement – block
    /// </summary>
    class LamdaExpressions
    {
        class Traditionalway
        {
            //declare delegate
            delegate int DoWork(string work);

            //have a method to create an instance of and call the delegate
            public void WorkItOut()
            {
                //declare instance
                DoWork dw = new DoWork(DoWorkMethodImpl);
                //invoke delegate
                int i = dw("Do work in Traditional way");
            }
            //Have a method that delegate is tied to with a matching signature
            //so that it is invoked when delegate is called
            public int DoWorkMethodImpl(string s)
            {
                Console.WriteLine(s);
                return s.GetHashCode();
            }
        }
        class Lambdaway
        {
            //declare delegate
            delegate int DoWork(string work);

            //have a method to create an instance of and call the delegate
            public void WorkItOut()
            {
                //declare instance
                DoWork dw = s =>
                {
                    Console.WriteLine(s);
                    return s.GetHashCode();
                };
                //invoke delegate
                int i = dw("Do some inline work");
            }
        }
    }
}
