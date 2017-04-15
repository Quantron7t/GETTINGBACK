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
            throw new NotImplementedException();
        }

        public void Delete(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Read()
        {
            using (sqlCon = new SqlConnection(sqlConString))
            {
                string readCommand = "Select * from employee";
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
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
