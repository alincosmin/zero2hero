using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesManagers;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StoreService
{
    public class Store
    {
        public static List<Employee> EmpList
        {
            //get
            //{
            //    List<Employee> _list = (List<Employee>)HttpContext.Current.Session["Employees"];
            //    if (_list == null)
            //    {
            //        HttpContext.Current.Session["Employees"] = new List<Employee>();
            //        _list = (List<Employee>)HttpContext.Current.Session["Employees"];
            //    }
            //    return _list;
            //}
            get
            {
                List<Employee> _list = new List<Employee>();

                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EmpConnString"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("ListEmps", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                int[] pair = new int[100];
                int i = 0;
                while(rdr.Read())
                {
                    Employee _temp = new Employee();
                    _temp.Id = Convert.ToInt32(rdr["empid"]);
                    _temp.Name = (string)rdr["name"];
                    _temp.Salary = Convert.ToInt32(rdr["Salary"]);
                    _list.Add(_temp);
                    if (rdr["mgr"] != DBNull.Value)
                    {
                        pair[_temp.Id] = Convert.ToInt32(rdr["mgr"]);
                    }
                    else pair[_temp.Id] = 0;
                }
                conn.Close();
                i = 0;
                Employee _temp2;
                while (i < 100)
                {
                    if(pair[i] == 0)
                    {
                        i++;
                        continue;
                    }
                    _temp2 = _list.Find(x => x.Id == i);
                    if (_temp2 != null)
                        _temp2.Manager = _list.Find(x => x.Id == pair[i]);
                    i++;
                }
                
                return _list;
            }

        }

        public static void Add(Employee _emp)
        {
            Random rnd = new Random();
            _emp.Id = rnd.Next(1, 1000);
            while (EmpList.Find(x => x.Id == _emp.Id) != null)
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
