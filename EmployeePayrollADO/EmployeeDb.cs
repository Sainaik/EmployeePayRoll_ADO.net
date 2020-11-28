using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace EmployeePayrollADO
{
    class EmployeeDb
    {
        public static string connectionString = "Data Source=(LocalDb)\\LocalDbssms;Initial Catalog= payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void getAllEmployee()
        {
            try
            {
                Employee employee = new Employee();
                using (this.connection)
                {
                    //string query = @"SELECT id,name,start,Gender,phoneNumber,address,department,
                                    //basic_pay,deductions,income_tax,net_salary,
                                    //FROM employee_payroll";

                   string query = @"select * from employee_payroll";


                   SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employee.EmployeeID = dr.GetInt32(0);
                            employee.EmployeeName = dr.GetString(1);
                            employee.StartDate = dr.GetDateTime(2);
                            employee.Gender = Convert.ToChar(dr.GetString(3));
                            employee.PhoneNumber = dr.GetString(4);
                            employee.Address = dr.GetString(5);
                            employee.Department = dr.GetString(6);
                            employee.BasicPay = Convert.ToDouble(dr.GetDecimal(7));
                            employee.Deductions = Convert.ToDouble(dr.GetDecimal(8));                         
                            employee.IncomeTax = Convert.ToDouble(dr.GetDecimal(9));
                            employee.NetSalary = Convert.ToDouble(dr.GetDecimal(10));
                           

                            Console.WriteLine($" {employee.EmployeeID}, {employee.EmployeeName}, {employee.Address}, {employee.Department}, {employee.BasicPay}");
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }

                    dr.Close();

                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool addEmployee(Employee employee)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", employee.EmployeeName);
                    command.Parameters.AddWithValue("@phone_number", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@address", employee.Address);
                    command.Parameters.AddWithValue("@department", employee.Department);
                    command.Parameters.AddWithValue("@gender", employee.Gender);
                    command.Parameters.AddWithValue("@basic_pay", employee.BasicPay);
                    command.Parameters.AddWithValue("@deductions", employee.Deductions);
                    command.Parameters.AddWithValue("@tax", employee.IncomeTax);
                    command.Parameters.AddWithValue("@net_pay", employee.NetSalary);
                    command.Parameters.AddWithValue("@start_Date", employee.StartDate);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
