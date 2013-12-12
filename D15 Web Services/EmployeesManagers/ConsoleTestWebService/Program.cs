using ConsoleTestWebService.com.w3schools.www;
using ConsoleTestWebService.localhost;
using ConsoleTestWebService.localhost1;
using System;

namespace ConsoleTestWebService
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- com.w3schools.www ---");
            var myvar = new TempConvert();
            string x = "30";
            string y = "300";
            Console.WriteLine(x + " Celsius: " + myvar.CelsiusToFahrenheit("30") + " Fahrenheit");
            Console.WriteLine(y + " Fahrenheit: " + myvar.FahrenheitToCelsius("300") + " Celsius");

            Console.WriteLine("\n--- localhost.Calculator ---");
            var z = new Calculator();
            Console.WriteLine("HelloWorld(): " + z.HelloWorld());
            int x2 = 30;
            int y2 = 12;
            Console.WriteLine("Sum(" + x2 + ", " + y2 + "): " + z.Sum(x2, y2));

            var Employees = new EmployeesWebService();
            var list = Employees.GetAll();
            foreach (Employee employee in list)
            {
                Console.WriteLine(employee.Id + "| " + employee.FirstName + ' ' + employee.LastName
                                  + "< " + employee.Manager.FirstName + ' ' + employee.Manager.LastName + "> "
                                  + employee.City.Name + ' ' + employee.Salary);
            }
        }   
    }
}
