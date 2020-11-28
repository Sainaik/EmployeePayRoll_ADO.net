using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollADO
{
    class Employee
    {
        public int  EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
       
        public double IncomeTax { get; set; }
        public double NetSalary { get; set; }
        public DateTime StartDate { get; set; }

    }

}
