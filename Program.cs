using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using System.IO;


namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***** First my programm with OOP *****");

            List<Employee> myOffice = TestFillArray();

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

            SaveAsXmlFormat(myOffice, "Employees.xml");

            List<Employee> newOffice = LoadFromXmlFormat("Employees.xml");
            if (newOffice != null)
            {
                foreach (var i in newOffice)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Ошибка чтения XML файла!");
            }

            Console.ReadLine();
        } // Main


        static List<Employee> TestFillArray()
        {
            return new List<Employee> 
            {
                new EmployeeTimed(1,"Tom Clancy", 3),
                new EmployeeFixed(2, "Bruse Willis", 800),
                new EmployeeFixed(3, "Mark Twen",1000),
                new EmployeeTimed(4, "Tom Cruse", 5),
                new EmployeeTimed(5, "Gabriel March", 5.5),
                new EmployeeFixed(6, "Martin Marvell", 1350),
                new EmployeeFixed(7, "Piter Parker",1000),
                new EmployeeFixed(8, "Calvn Cleyn",500),
                new EmployeeTimed(9, "Miky Mause", 10),
                new EmployeeTimed(10, "Mini Mause", 12)
            };
        }


        static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            // Сохранить объект в формате XML.
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Employee>));
                using (Stream fStream = new FileStream(fileName,
                        FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fStream, objGraph);
                }
                Console.WriteLine("=> Saved car in XML format!");
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        } // SaveAsXmlFormat

        static List<Employee> LoadFromXmlFormat(string fileName)
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Employee>));
                using (Stream fStream = new FileStream(fileName,
                        FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return (List<Employee>)xmlFormat.Deserialize(fStream);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

    } // Programm
}
