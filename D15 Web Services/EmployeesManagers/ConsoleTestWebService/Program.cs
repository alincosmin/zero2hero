using System;

namespace ConsoleTestWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- com.w3schools.www ---");
            var myvar = new com.w3schools.www.TempConvert();
            string x = "30";
            string y = "300";
            Console.WriteLine(x + " Celsius: " + myvar.CelsiusToFahrenheit("30") + " Fahrenheit");
            Console.WriteLine(y + " Fahrenheit: " + myvar.FahrenheitToCelsius("300") + " Celsius");

            Console.WriteLine("\n--- localhost.Calculator ---");
            var z = new localhost.Calculator();
            Console.WriteLine("HelloWorld(): " + z.HelloWorld());
            int x2 = 30;
            int y2 = 12;
            Console.WriteLine("Sum(" + x2.ToString() + ", " + y2.ToString() + "): " + z.Sum(x2,y2).ToString());
        }   
    }
}
