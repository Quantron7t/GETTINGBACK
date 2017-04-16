using System;
using OrganizationObjects;
using BusinessLayer;
using System.Collections.Generic;
using System.Threading;
namespace ConsoleApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            EmployeeData eD = new EmployeeData();

            List<Employee> employeeList;
            Employee employee;
            employee = new Employee();

            DisplayRecords(employeeList=new List<Employee>(eD.Read()));

            //READ BY ID
            Console.WriteLine("Enter an id to display a record");
            employee = eD.ReadById(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("ID : " + employee.Id + "\n" + "NAME : " + employee.Name + "\n" + "LOCATION : " + employee.Location + "\n" + "SALARY : " + employee.Salary + "\n" + "GRADE : " + employee.Grade);

            //CREATE A NEW RECORD
            Console.WriteLine("Create a new record by entering the following details");
            Console.WriteLine("Please enter employee ID : ");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter employee NAME : ");
            employee.Name = Console.ReadLine().ToString();
            Console.WriteLine("Please enter employee LOCATION : ");
            employee.Location = Console.ReadLine().ToString();
            Console.WriteLine("Please enter employee SALARY : ");
            employee.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter employee GRADE : ");
            employee.Grade = Console.ReadLine().ToString()[0];

            eD.Create(employee);

            //UPDATE A NEW RECORD
            Console.WriteLine("Update record by entering the following details");
            Console.WriteLine("Please enter employee ID to update : ");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter employee NAME : ");
            employee.Name = Console.ReadLine().ToString();
            Console.WriteLine("Please enter employee LOCATION : ");
            employee.Location = Console.ReadLine().ToString();
            Console.WriteLine("Please enter employee SALARY : ");
            employee.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter employee GRADE : ");
            employee.Grade = Console.ReadLine().ToString()[0];

            eD.Update(employee);

            //DELETE A NEW RECORD
            Console.WriteLine("Please enter the employee ID to be deleted : ");
            eD.Delete(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Updated records table");
            employeeList = new List<Employee>(eD.Read());
            DisplayRecords(employeeList);

            Console.ReadLine();
        }

        private static void DisplayRecords(List<Employee> employeeList)
        {
            //READ ALL RECORDS
            Console.WriteLine(" -----------------------------------------------------------------------------------------------------");
            Console.WriteLine("| ID  NAME                          LOCATION                      SALARY              GRADE           |");
            Console.WriteLine(" -----------------------------------------------------------------------------------------------------");
            Thread.Sleep(400);//BadAssEffect
            foreach (var item in employeeList)
            {
                Console.WriteLine("| {0,-4}{1,-30}{2,-30}{3,-20}{4,-16}|", item.Id, item.Name, item.Location, item.Salary, item.Grade);
                Thread.Sleep(300);//BadAssEffect
                //Console.WriteLine(item.Id+" "+item.Name+ "->" +item.Location+ "->" +item.Salary+ "->" +item.Grade);
            }
            Console.WriteLine(" -----------------------------------------------------------------------------------------------------");
        }
    }
}