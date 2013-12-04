using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesManagers;
using System.Web;

namespace StoreService
{
    public class Store
    {
        public static List<Employee> EmpList {
            get
            {
                List<Employee> _list = (List<Employee>)HttpContext.Current.Session["Employees"];
                if (_list == null)
                {
                    HttpContext.Current.Session["Employees"] = new List<Employee>();
                    _list = (List<Employee>)HttpContext.Current.Session["Employees"];
                }
                return _list;
            }

        }

        public static void Add(Employee _emp)
        {
            Random rnd = new Random();
            _emp.Id = rnd.Next(1, 1000);
            while(EmpList.Find(x => x.Id == _emp.Id)!=null)
            {
                _emp.Id = rnd.Next(1, 1000);
            }
            EmpList.Add(_emp);
        }

        public static void Replace(Employee _new, Employee _old)
        {
            Employee _temp = EmpList.Find(x => x.Id == _old.Id);
            if (_temp != null)
            {
                _temp.Manager = _new.Manager;
                _temp.Name = _new.Name;
                _temp.Salary = _new.Salary;
                _temp.City = _new.City;
            }
        }
    }
}
