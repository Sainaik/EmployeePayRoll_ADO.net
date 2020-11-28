using System;

namespace EmployeePayrollADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Employee employee = new Employee();
            EmployeeDb employeeRepo = new EmployeeDb();

            employee.EmployeeName = "Purple";
            employee.PhoneNumber = "3216549870";
            employee.Address = "Alaska";
            employee.Department = "Marketing";
            employee.Gender = 'F';
            employee.BasicPay = 280000;
            employee.Deductions = 4357.54;
            employee.IncomeTax = 756.23;
            employee.NetSalary = 273234.23;
            employee.StartDate = Convert.ToDateTime("2020-10-13");

            employeeRepo.addEmployee(employee);
            employeeRepo.getAllEmployee();
        }
    }
}
