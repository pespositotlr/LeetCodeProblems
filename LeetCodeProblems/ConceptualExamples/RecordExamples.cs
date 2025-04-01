using Microsoft.Office.Interop.Excel;
using RestSharp;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeProblems.ConceptualExamples
{
    internal class RecordExamples
    {
        public void RecordExamples_Main()
        {
            //Value-Based Equality
            //Reduces boilerplate code for equality comparisons.
            //Avoids writing Equals() and GetHashCode() manually.
            var person1 = new Person("Alice", 30);
            var person2 = new Person("Alice", 30);

            Console.WriteLine(person1 == person2); // true (value-based equality)


            //Pattern Matching & Deconstruction
            //Improves readability.
            //Simplifies data extraction.
            var employee = new RecordExamples_Employee("John", "Developer");
            var (name, job) = employee; // Deconstruction

            //With expression for mutation
            //Encourages immutability while allowing controlled modifications.
            //Useful in functional programming paradigms.
            var original = new Product("Laptop", 1200);
            var updated = original with { Price = 1100 }; // Creates a new instance


            //When working with lots of immutable data (e.g., logs, events, analytics), records reduce memory pressure and enhance processing efficiency.

            //When NOT to Use a Record?
            //🚫 If you need mutable objects → Use class instead.
            //🚫 If reference equality is required → Use class instead.
            //🚫 For complex behavior-heavy objects → Use class with methods and properties.

            //When to Use record?
            //✅ DTOs and API models
            //✅ Immutable domain models
            //✅ Value-based equality objects
            //✅ Functional programming(pattern matching, with expressions)
            //✅ Thread-safe, read-only objects
        }

    }

    //Data Transfer Objects (DTOs)
    public record OrderDto(int Id, string CustomerName, decimal TotalAmount);

    //Read Only Data Model
    public record Product(string Name, decimal Price);

    //Value-Based Equality
    public record Person(string Name, int Age);

    //Pattern Matching & Deconstruction
    public record RecordExamples_Employee(string Name, string JobTitle);
}
