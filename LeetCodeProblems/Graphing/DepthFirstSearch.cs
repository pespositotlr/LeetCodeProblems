using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://www.csharpstar.com/csharp-depth-first-seach-using-list/
    /// Depth-first search (DFS) is an algorithm for traversing or searching tree or graph data structures. 
    /// One starts at the root (selecting some arbitrary node as the root in the case of a graph) and explores as far as possible along each branch before backtracking.
    /// </summary>
    class DepthFirstSearch
    {

        public class DepthFirstAlgorithm
        {
            //              Eva
            //          /          \
            //        Sophia     Brian
            //       /    \      /    \
            //      Lisa  John  Tina   Mike
            public Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);

                Employee Lisa = new Employee("Lisa");
                Employee Tina = new Employee("Tina");
                Employee John = new Employee("John");
                Employee Mike = new Employee("Mike");
                Sophia.isEmployeeOf(Lisa);
                Sophia.isEmployeeOf(John);
                Brian.isEmployeeOf(Tina);
                Brian.isEmployeeOf(Mike);

                return Eva;
            }

            //Traverses using recursion to go to "end nodes" first. 
            //Checks whole "Sophia Side" before checking the "Brian side
            public Employee Search(Employee root, string nameToSearchFor)
            {
                if (nameToSearchFor == root.name)
                    return root;

                Employee personFound = null;
                for (int i = 0; i < root.Employees.Count; i++)
                {
                    personFound = Search(root.Employees[i], nameToSearchFor);
                    if (personFound != null)
                        break;
                }
                return personFound;
            }

            //Traverses using recursion to go to "end nodes" first. 
            //Checks whole "Sophia Side" before checking the "Brian side
            public void Traverse(Employee root)
            {
                Console.WriteLine(root.name);
                for (int i = 0; i < root.Employees.Count; i++)
                {
                    Traverse(root.Employees[i]);
                }
            }
        }

    }
}
