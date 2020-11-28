using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
u


namespace EmployeePayrollADO
{
    class EmployeeDb
    {
        public static string connectionString = "Data Source=(LocalDb)\\LocalDbssms;Initial Catalog= payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
    }
}
