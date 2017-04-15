using System;
using System.Collections.Generic;
using System.Text;
using OrganizationObjects;
using AdoRepository;


namespace BusinessLayer
{
    public class EmployeeData : IManageEmployee
    {
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
            AdoDataAccessLayer adoAccess = new AdoDataAccessLayer();
            List<Employee> employeeList = new List<Employee>(adoAccess.Read());
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
