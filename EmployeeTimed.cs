using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{

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
  
    
    
    
    
    
    
    
    }
}

    

