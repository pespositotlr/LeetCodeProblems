using LeetCodeProblems.ConceptualExamples;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://www.csharpstar.com/csharp-breadth-first-search/
    /// Breadth-first search (BFS) is an algorithm for traversing or searching tree or graph data structures.    
    /// It starts at the tree root (or some arbitrary node of a graph) and explores the neighbor nodes first, before moving to the next level neighbors.
    /// </summary>
    class BreadthFirtstSearch
    {

        public class BreadthFirstAlgorithm
        {
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

            public Employee Search(Employee root, string nameToSearchFor)
            {
                Queue<Employee> Q = new Queue<Employee>();
                HashSet<Employee> S = new HashSet<Employee>();
                Q.Enqueue(root);
                S.Add(root);

                while (Q.Count > 0)
                {
                    Employee e = Q.Dequeue();
                    if (e.name == nameToSearchFor)
                        return e;
                    foreach (Employee friend in e.Employees)
                    {
                        if (!S.Contains(friend))
                        {
                            Q.Enqueue(friend);
                            S.Add(friend);
                        }
                    }
                }
                return null;
            }

            public void Traverse(Employee root)
            {
                Queue<Employee> traverseOrder = new Queue<Employee>();

                Queue<Employee> employeeQueue = new Queue<Employee>();
                HashSet<Employee> employeeHashSet = new HashSet<Employee>();
                employeeQueue.Enqueue(root);
                employeeHashSet.Add(root);

                while (employeeQueue.Count > 0)
                {
                    Employee e = employeeQueue.Dequeue();
                    traverseOrder.Enqueue(e);

                    foreach (Employee emp in e.Employees)
                    {
                        if (!employeeHashSet.Contains(emp))
                        {
                            employeeQueue.Enqueue(emp);
                            employeeHashSet.Add(emp);
                        }
                    }
                }

                while (traverseOrder.Count > 0)
                {
                    Employee e = traverseOrder.Dequeue();
                    Console.WriteLine(e);
                }
            }
        }

    }
}
