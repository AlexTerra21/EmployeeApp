using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    abstract class Employee
    {
        // Поля
        public int ID { get; set; } // ID сотрудника
        public string Name { get; set; } // Имя сотрудника
        public double Salary { get; set; } // Зарплата сотрудника

        // Конструкторы
        public Employee() { }
        public Employee(int id, string name)
        {
            ID = id;
            Name = name;
        }
        
        // Методы

        // Вывод данных объекта
        public override string ToString()
        {
            return string.Format("ID= {0} Employee {1} has salary ${2}", ID, Name, Salary);
        }

        // Абстрактный метод для расчета зарплаты
        // переопределяется для потомков
        abstract public double Payroll(double rate);
    } // Employee

    // Сотрудник с фиксированной зарплатой
    class EmployeeFixed : Employee
    {
        public EmployeeFixed(int id, string name, double rate)
            : base(id, name)
        {
            Salary = Payroll(rate);
        }

        public override double Payroll(double rate)
        { return rate; }
    } // EmployeeFixed

    // Сотрудник с почасовой зарплатой
    class EmployeeTimed : Employee
    {
        public EmployeeTimed(int id, string name, double rate)
            : base(id, name)
        {
            Salary = Payroll(rate);
        }

        public override double Payroll(double rate)
        { return 20.8 * 8 * rate; }
    } // EmployeeTimed

}
