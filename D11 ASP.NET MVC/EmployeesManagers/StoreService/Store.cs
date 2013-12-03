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
                    _list = new List<Employee>();
                return _list;
            }

            set
            {
                HttpContext.Current.Session["Employees"] = (List<Employee>)value;
            }
        }

        public static void Add(Employee _emp)
        {
            EmpList.Add(_emp);
        }

        public static void Replace(Employee _new, Employee _old)
        {
            Employee _temp = EmpList.Find(x => x.Id == _old.Id);
            if (_temp == null)
                return;
            _temp.Manager = _new.Manager;
            _temp.Name = _new.Name;
            _temp.Salary = _new.Salary;
            _temp.City = _new.City;
        }
    }
}
