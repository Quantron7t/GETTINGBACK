using System;
using OrganizationObjects;
using System.Collections.Generic;

namespace BusinessLayer
{
    interface IManageEmployee
    {
        void Create(Employee employee);
        List<Employee> Read();
        void Update(Employee employee);
        void Delete(int employeeId);
        Employee ReadById(int employeeId);
    }
}
