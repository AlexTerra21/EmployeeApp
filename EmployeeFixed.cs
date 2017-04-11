using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    // Сотрудник с фиксированной зарплатой
    class EmployeeFixed : Employee
    {
         public EmployeeFixed(int id, string name, double rate)
            : base (id, name)
        {
            Salary = Payroll(rate);
        }

        public override double Payroll(double rate)
        {   return rate; }
    }
}
