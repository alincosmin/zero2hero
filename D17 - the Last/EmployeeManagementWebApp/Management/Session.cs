using System;
using System.Collections.Generic;
using System.Web;
using EmployeeEntity;

namespace Management
{
    public class Session
    {
        public List<Employee> EmployeeList
        {
            get
            {
                List<Employee> list = (List<Employee>)HttpContext.Current.Session["EmployeeList"];
                if (list == null)
                {
                    HttpContext.Current.Session["EmployeeList"] = new List<Employee>();
                    list = (List<Employee>)HttpContext.Current.Session["EmployeeList"];
                }
                return list;
            }
        }

        public Employee Get(int id)
        {
            return EmployeeList.Find(x => x.Id == id);
        }

        public void Add(Employee employee)
        {
            Random rnd = new Random();
            employee.Id = rnd.Next(1, 10000);
            while (EmployeeList.Find(x => x.Id == employee.Id) != null)
                employee.Id = rnd.Next(1, 10000);
            
            EmployeeList.Add(employee);
        }

        public void Update(Employee employee)
        {
            Employee _employee = EmployeeList.Find(x => x.Id == employee.Id);
            if (_employee != null)
            {
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
                _employee.Salary = employee.Salary;
                _employee.Manager = employee.Manager;
            }
        }

        public void Delete(int id)
        {
            Employee _employee = EmployeeList.Find(x => x.Id == id);
            if (_employee != null)
                EmployeeList.Remove(_employee);
        }

    }
}
