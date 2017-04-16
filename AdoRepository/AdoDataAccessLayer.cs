using System;
using System.Collections.Generic;
using OrganizationObjects;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace AdoRepository
{
    public class AdoDataAccessLayer 
    {
        SqlConnection sqlCon;
        SqlCommand sqlCom;
        SqlDataReader sqlDataReader;
        string sqlConString = "Data Source=TRON-PC;Initial Catalog=BsilRetry;Integrated Security=True";
        public List<Employee> employeeList = new List<Employee>();

        public void Create(Employee employee)
        {
            using (sqlCon = new SqlConnection(sqlConString))
            {
                string createCommand = "Insert into employee values(@id,@name,@location,@salary,@grade)";
                sqlCom = new SqlCommand(createCommand,sqlCon);
                sqlCon.Open();
                sqlCom.Parameters.AddWithValue("@id",employee.Id);
                sqlCom.Parameters.AddWithValue("@name",employee.Name);
                sqlCom.Parameters.AddWithValue("@location",employee.Location);
                sqlCom.Parameters.AddWithValue("@salary",employee.Salary);
                sqlCom.Parameters.AddWithValue("@grade",employee.Grade);
                sqlCom.ExecuteNonQuery();
            }
        }

        public void Delete(int employeeId)
        {
            using (sqlCon=new SqlConnection(sqlConString))
            {
                string deleteCommand = "Delete from employee where id="+employeeId;
                sqlCom = new SqlCommand(deleteCommand,sqlCon);
                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
            }
        }

        public List<Employee> Read()
        {
            using (sqlCon = new SqlConnection(sqlConString))
            {
                string readCommand = "Select * from employee order by id ASC";
                sqlCom = new SqlCommand(readCommand,sqlCon);
                sqlCon.Open();
                using (sqlDataReader=sqlCom.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        employeeList.Add(new Employee() { Id = (int)sqlDataReader["id"],Name = sqlDataReader["name"].ToString(),Location=sqlDataReader["location"].ToString(),Salary=(int)sqlDataReader["salary"],Grade=sqlDataReader["grade"].ToString()[0]});//[0] makes sure the data type is converted to char
                    }
                }
            }
            return employeeList;
        }

        public Employee ReadById(int employeeId)
        {
            Employee employee = new Employee();
            using (sqlCon=new SqlConnection(sqlConString))
            {
                string readByIdCommand = "Select * from employee where id=" + employeeId;
                sqlCom = new SqlCommand(readByIdCommand, sqlCon);
                sqlCon.Open();
                using (sqlDataReader=sqlCom.ExecuteReader())
                {
                    sqlDataReader.Read();
                    employee.Id = (int)sqlDataReader["id"];
                    employee.Name = sqlDataReader["name"].ToString();
                    employee.Location = sqlDataReader["location"].ToString();
                    employee.Salary = (int)sqlDataReader["salary"];
                    employee.Grade = sqlDataReader["grade"].ToString()[0];
                }
            }
            return employee;
        }

        public void Update(Employee employee)
        {
            using (sqlCon=new SqlConnection(sqlConString))
            {
                string updateCommand = "update employee set name=@name,location=@location,salary=@salary,grade=@grade where id=" + employee.Id;
                sqlCom = new SqlCommand(updateCommand,sqlCon);
                sqlCon.Open();
                sqlCom.Parameters.AddWithValue("@name",employee.Name);
                sqlCom.Parameters.AddWithValue("@location", employee.Location);
                sqlCom.Parameters.AddWithValue("@salary", employee.Salary);
                sqlCom.Parameters.AddWithValue("@grade", employee.Grade);
                sqlCom.ExecuteNonQuery();
            }
        }
    }
}
