using System;
using System.Collections.Generic;

namespace EmployeesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WebEmployees.Employees();
            var employee = new WebEmployees.Employee();
            employee.FirstName = "Gica";
            employee.LastName = "Hagi";
            employee.Salary = 123;
            Console.Write("Adaugare angajat... ");
            service.Create(employee);
            Console.WriteLine("Gata!");
            Console.WriteLine("Listare angajati:");

            foreach (var e in service.GetAll())
            {
                Console.WriteLine(e.Id + ") " + e.FirstName + " " + e.LastName + " " + e.Salary);
            }
            Console.WriteLine("Afisare completa!");
            Console.Write("Editare 28...");
            var emp = service.Get(28);
            emp.FirstName = "Nume editat";
            service.Update(emp);
            Console.WriteLine(" Gata!");
            Console.WriteLine("Listare angajati:");

            foreach (var e in service.GetAll())
            {
                Console.WriteLine(e.Id + ") " + e.FirstName + " " + e.LastName + " " + e.Salary);
            }
            Console.WriteLine("Afisare completa!");
            

        }
    }
}
