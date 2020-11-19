using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    class AddressSelect
    {
        public class Address
        {
            public String StreetName { get; set; }
            public String City { get; set; }
            public String State { get; set; }
            public String Zipcode { get; set; }
        }

        public class Person
        {
            public String Name { get; set; }
            public String City { get; set; }
            public String State { get; set; }
            public String Zipcode { get; set; }
        }
        public void Solution()
        {
            List<Address> addresses = new List<Address>();

            addresses.Add(new Address() { StreetName = "Test1", City = "New York City", State = "New York", Zipcode = "10000" });
            addresses.Add(new Address() { StreetName = "Test1", City = "Lynbrook", State = "New York", Zipcode = "10000" });
            addresses.Add(new Address() { StreetName = "Test1", City = "Trenton", State = "New Jersey", Zipcode = "10000" });
            addresses.Add(new Address() { StreetName = "Test1", City = "Daytona", State = "Florida", Zipcode = "10000" });

            var result1 = addresses.Select(x => x.City).ToList();

            var result2 = addresses.Where(x => x.State.StartsWith("N")).Select(x => x.City).ToList();

            var p1 = new Person() { Name = "Jon" };
            var p2 = new Person() { Name = "Jon" };

            ChangePerson(p1); //This won't actually change the name

            ChangePersonRef(ref p1);

            RenamePerson(p2);

            Console.WriteLine(p1 == p2);       //WHAT WILL THIS LINE DISPLAY?
            Console.WriteLine(p1.Equals(p2));  //WHAT WILL THIS LINE DISPLAY?

        }
        public void RenamePerson(Person person)
        {
            person.Name = "William";
        }
        public void ChangePerson(Person person)
        {
            person = new Person() { Name = "Bill" };
        }

        public void ChangePersonRef(ref Person person)
        {
            person = new Person() { Name = "Bill" };
        }

    }
}
