using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeesManagers
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public Employee Manager { get; set; }
        public City City { get; set; }
    }
}
