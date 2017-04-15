using System;
using System.Collections.Generic;
using OrganizationObjects;
using System.Text;

namespace BusinessLayer
{
    interface IManageEmployee
    {
        void Create(Employee employee);
        void Delete(int employeeId);
        List<Employee> Read();
        Employee ReadById(int employeeId);
    }
}
