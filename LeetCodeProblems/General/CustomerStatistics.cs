#pragma warning disable
using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Net;

namespace LeetCodeProblems.General
{
    class CustomerStatistics
    {
        public static void MainCustomerStatistics()
        {
            List<CustomerInfo> customerInfos = new List<CustomerInfo>();
            SortedDictionary<string, int> citiesCountDictionary = new SortedDictionary<string, int>();
            SortedDictionary<string, int> countriesCountDictionary = new SortedDictionary<string, int>();
            SortedDictionary<string, int> countriesContractCountDictionary = new SortedDictionary<string, int>();
            string largestContractCountCountry = "";
            int largestContractCountValue = 0;

            using (var reader = new StreamReader(@"/root/customers/data.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values[0] == "ID")
                        continue;

                    var newCustomer = new CustomerInfo();

                    //Fetch data from line of csv
                    newCustomer.Id = Convert.ToInt32(values[0]);
                    newCustomer.Name = values[1];
                    newCustomer.City = values[2];
                    newCustomer.Country = values[3];
                    newCustomer.CPerson = values[4];
                    newCustomer.EmplCnt = Convert.ToInt32(values[5]);
                    newCustomer.ContrCnt = Convert.ToInt32(values[6]);
                    newCustomer.ContrCost = Convert.ToDecimal(values[7]);

                    //Keep track of count of customers from city
                    if (!citiesCountDictionary.ContainsKey(newCustomer.City))
                        citiesCountDictionary.Add(newCustomer.City, 1);
                    else
                        citiesCountDictionary[newCustomer.City]++;

                    //Keep track of count of customers from country
                    if (!countriesCountDictionary.ContainsKey(newCustomer.Country))
                        countriesCountDictionary.Add(newCustomer.Country, 1);
                    else
                        countriesCountDictionary[newCustomer.Country]++;

                    //Keep track of Contract Count in each country
                    if (!countriesContractCountDictionary.ContainsKey(newCustomer.Country))
                        countriesContractCountDictionary.Add(newCustomer.Country, newCustomer.ContrCnt);
                    else
                        countriesContractCountDictionary[newCustomer.Country] += newCustomer.ContrCnt;

                    if (countriesContractCountDictionary[newCustomer.Country] > largestContractCountValue)
                    {
                        largestContractCountCountry = newCustomer.Country;
                        largestContractCountValue = countriesContractCountDictionary[newCustomer.Country];
                    }
                    else if (countriesContractCountDictionary[newCustomer.Country] == largestContractCountValue)
                    {
                        largestContractCountCountry = newCustomer.Country.Length > largestContractCountCountry.Length ? newCustomer.Country : largestContractCountCountry;
                    }

                    customerInfos.Add(newCustomer);
                }
            }

            //Print output
            Console.WriteLine("Total customers:");
            Console.WriteLine(customerInfos.Count);
            Console.WriteLine("Customers by city:");
            foreach(KeyValuePair<string, int> kvp in citiesCountDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine("Customers by country:");
            foreach (KeyValuePair<string, int> kvp in countriesCountDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine("Country with the largest number of customers' contracts:");
            Console.WriteLine($"{largestContractCountCountry} ({largestContractCountValue} contracts)");
            Console.WriteLine("Unique cities with at least one customer:");
            Console.WriteLine(citiesCountDictionary.Count);


        }
        public class CustomerInfo
        {
            /// <summary>
            /// Unique id of the customer
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Official customer company name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Location city name
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// Location country name
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// Email of the customer company contact person
            /// </summary>
            public string CPerson { get; set; }

            /// <summary>
            /// Customer company employees number
            /// </summary>
            public int EmplCnt { get; set; }

            /// <summary>
            /// Number of contracts signed with the customer
            /// </summary>
            public int ContrCnt { get; set; }

            /// <summary>
            /// Total amount of money paid by customer(float in format dollars.cents)
            /// </summary>
            public decimal ContrCost { get; set; }
        }
    }
}
