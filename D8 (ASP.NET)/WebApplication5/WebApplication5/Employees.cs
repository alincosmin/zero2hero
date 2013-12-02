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

    public static void Edit(Employee E, string name, int mgrid, double sal)
    {
        List<Employee> list = (List<Employee>)HttpContext.Current.Session["Employees"];
        if (list.Contains(E))
        {
            list.Remove(E);
            list.Add(new Employee(E.Id, name, list.Find(x => x.Id == mgrid),sal));
            HttpContext.Current.Session["Employees"] = list;
        }
    }

}