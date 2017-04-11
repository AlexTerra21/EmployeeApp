using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***** First my programm with OOP *****");

            List<Employee> myOffice = new List<Employee> 
            {
                new EmployeeTimed(1,"Tom Clancy", 3),
                new EmployeeFixed(2, "Bruse Willis", 800),
                new EmployeeFixed(3, "Mark Twen",1000),
                new EmployeeTimed(4, "Tom Cruse", 5),
                new EmployeeTimed(5, "Gabriel March", 5.5),
                new EmployeeFixed(6, "Martin Marvell", 1350),
                new EmployeeFixed(7, "Piter Parker",1000)
            };

            Console.WriteLine("Исходный список");

            foreach (var i in myOffice)
            { Console.WriteLine(i); }

            Console.WriteLine("Сортированный список");

            var sorted = from p1 in myOffice
                     orderby p1.Salary,p1.Name
                     select p1;

            foreach (var i in sorted)
            { Console.WriteLine(i); }

            Console.WriteLine("Имена первыех 5-и сотрудников с наименьшими зарплатами");

            foreach (var i in sorted.Take(5))
            { 
                Console.WriteLine(i.Name);
            }

            Console.WriteLine("ID последних 3-х  сотрудников с наибольшими зарплатами");

            foreach (var i in sorted.Skip(sorted.Count()-3))
            {
                Console.WriteLine(i.ID);
            }

            Console.ReadLine();
        }
    }
}
