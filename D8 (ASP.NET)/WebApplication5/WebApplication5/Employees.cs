using System;
using System.Collections.Generic;
using System.Web;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Employee Manager { get; set; }
    public double Salary { get; set; }

    public Employee(int i,string n, Employee m, double s)
    {
        Id = i;
        Name = n;
        Manager = m;
        Salary = s;
    }
}

class EmployeeService
{
    
    public static List<Employee> GetAll()
    {
        List<Employee> E = (List<Employee>)HttpContext.Current.Session["Employees"];

        return E;
    }

    public static void Add(Employee e)
    {
        if (HttpContext.Current.Session["Employees"] == null)
            HttpContext.Current.Session["Employees"] = new List<Employee>();
        List<Employee> E = (List<Employee>)HttpContext.Current.Session["Employees"];
        
        E.Add(e);
    }

}