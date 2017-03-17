using System;

namespace OrganizationObjects
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Location { get => location; set => location = value; }
        public string Designation { get => designation; set => designation = value; }

        private string designation;

        private string location;
    }
}
