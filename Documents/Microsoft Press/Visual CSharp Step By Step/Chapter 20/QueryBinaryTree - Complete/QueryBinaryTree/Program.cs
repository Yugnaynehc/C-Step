using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryTree;

namespace QueryBinaryTree
{
    class Program
    {
        static void DoWork()
        {
            Tree<Employee> empTree = new Tree<Employee>(new Employee 
              { Id = 1, FirstName = "Janet", LastName = "Gates", Department = "IT"});
            empTree.Insert(new Employee 
              { Id = 2, FirstName = "Orlando", LastName = "Gee", Department = "Marketing"});
            empTree.Insert(new Employee 
              { Id = 4, FirstName = "Keith", LastName = "Harris", Department = "IT" });
            empTree.Insert(new Employee 
              { Id = 6, FirstName = "Lucy", LastName = "Harrington", Department = "Sales" });
            empTree.Insert(new Employee 
              { Id = 3, FirstName = "Eric", LastName = "Lang", Department = "Sales" });
            empTree.Insert(new Employee 
              { Id = 5, FirstName = "David", LastName = "Liu", Department = "Marketing" });

            Console.WriteLine("All employees");
            var allEmployees = from e in empTree.ToList<Employee>()
                               select e;

            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp);
            }

            empTree.Insert(new Employee
                               {
                                   Id = 7,
                                   FirstName = "Donald",
                                   LastName = "Blanton",
                                   Department = "IT"
                               });
            Console.WriteLine("\nEmployee added");

            Console.WriteLine("All employees");
            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp);
            }

            //Console.WriteLine("List of departments");
            ////var depts = empTree.Select(d => d.Department).Distinct();
            //var depts = (from d in empTree
            //             select d.Department).Distinct();

            //foreach (var dept in depts)
            //{
            //    Console.WriteLine("Department: {0}", dept);
            //}

            //Console.WriteLine("\nEmployees in the IT department");
            ////var ITEmployees =
            ////    empTree.Where(e => String.Equals(e.Department, "IT"))
            ////    .Select(emp => emp);
            //var ITEmployees = from e in empTree
            //                  where String.Equals(e.Department, "IT")
            //                  select e;

            //foreach (var emp in ITEmployees)
            //{
            //    Console.WriteLine(emp);
            //}

            //Console.WriteLine("\nAll employees grouped by department");
            ////var employeesByDept = empTree.GroupBy(e => e.Department);
            //var employeesByDept = from e in empTree
            //                      group e by e.Department;

            //foreach (var dept in employeesByDept)
            //{
            //    Console.WriteLine("Department: {0}", dept.Key);
            //    foreach (var emp in dept)
            //    {
            //        Console.WriteLine("\t{0} {1}", emp.FirstName, emp.LastName);
            //    }
            //}
        }

        static void Main()
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
