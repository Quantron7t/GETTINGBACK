using System;
using System.Collections.Generic;
using System.Text;
using OrganizationObjects;
using AdoRepository;


namespace BusinessLayer
{
    public class EmployeeData : IManageEmployee
    {
        AdoDataAccessLayer adoAccess;
        Employee employee;

        public void Create(Employee employee)
        {
            adoAccess = new AdoDataAccessLayer();
            adoAccess.Create(employee);
        }

        public void Delete(int employeeId)
        {
            adoAccess = new AdoDataAccessLayer();
            adoAccess.Delete(employeeId);
        }

        public List<Employee> Read()
        {
            adoAccess = new AdoDataAccessLayer();
            List<Employee> employeeList = new List<Employee>(adoAccess.Read());
            return employeeList;
        }

        public Employee ReadById(int employeeId)
        {
            adoAccess = new AdoDataAccessLayer();
            employee = new Employee();
            employee = adoAccess.ReadById(employeeId);
            return employee;
        }

        public void Update(Employee employee)
        {
            adoAccess = new AdoDataAccessLayer();
            adoAccess.Update(employee);
        }
    }
}
