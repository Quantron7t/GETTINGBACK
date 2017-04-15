using System;
using OrganizationObjects;
using BusinessLayer;
using System.Collections.Generic;
using System.Threading;
namespace ConsoleApp1
{
    class Program
    {
        public Program()
        {
            Employee employee = new Employee();
        }

        static void Main(string[] args)
        {
            EmployeeData eD = new EmployeeData();
            List<Employee> employeeList = new List<Employee>(eD.Read());
            
            Console.WriteLine(" -----------------------------------------------------------------------------------------------------");
            Console.WriteLine("| ID  NAME                          LOCATION                      SALARY              GRADE           |");
            Console.WriteLine(" -----------------------------------------------------------------------------------------------------");
            Thread.Sleep(400);//BadAssEffect
            foreach (var item in employeeList)
            {
                Console.WriteLine("| {0,-4}{1,-30}{2,-30}{3,-20}{4,-16}|", item.Id, item.Name, item.Location,item.Salary,item.Grade);
                Thread.Sleep(300);//BadAssEffect
                //Console.WriteLine(item.Id+" "+item.Name+ "->" +item.Location+ "->" +item.Salary+ "->" +item.Grade);
            }
            Console.WriteLine(" -----------------------------------------------------------------------------------------------------");
            Console.ReadLine();
        }
    }
}