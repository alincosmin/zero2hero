using System;
using System.Collections.Generic;
using EmployeeEntity;

namespace Management
{
    public class StaticList
    {
        public List<Employee> EmployeeList { get; set; }

        public StaticList()
        {
            EmployeeList = new List<Employee>();
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
