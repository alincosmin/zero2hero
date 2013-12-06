using System;
using System.Collections.Generic;
using EmployeesManagers;
using System.Data.SqlClient;
using System.Data;

namespace StoreService
{
    public class Store
    {
        private static MySqlProcedure _procedure;
       
        public static List<Employee> EmpList
        {
            get
            {
                List<Employee> list = new List<Employee>();
                _procedure = new MySqlProcedure();
                SqlDataReader rdr = _procedure.Reader("ListEmps", null);
                int[] pair = new int[100];
                while(rdr.Read())
                {
                    Employee temp = new Employee();
                    temp.Id = Convert.ToInt32(rdr["empid"]);
                    temp.Name = (rdr["name"] != DBNull.Value)?(string)rdr["name"]:"";
                    temp.Salary = (rdr["Salary"] != DBNull.Value) ? Convert.ToInt32(rdr["Salary"]) : 0;
                    list.Add(temp);
                    pair[temp.Id] = (rdr["mgr"] != DBNull.Value) ? Convert.ToInt32(rdr["mgr"]) : 0;
                }
                rdr.Close();
                int i = 0;
                Employee _temp2;
                while (i < 100)
                {
                    if(pair[i] == 0)
                    {
                        i++;
                        continue;
                    }
                    _temp2 = list.Find(x => x.Id == i);
                    if (_temp2 != null)
                        _temp2.Manager = list.Find(x => x.Id == pair[i]);
                    i++;
                }
                
                return list;
            }

        }

        public static void Add(Employee employee)
        {
            _procedure = new MySqlProcedure();
            Dictionary<string, object> Args = new Dictionary<string, object>
            {
                {"@fn",employee.Name},
                {"@sal",Convert.ToInt32(employee.Salary)}
            };
            if (employee.Manager != null)
                Args.Add("@mgr", employee.Manager.Id);
            _procedure.NoQuery("AddEmployee", Args);
        }

        public static void Update(Employee employee)
        {
            _procedure = new MySqlProcedure();
            Dictionary<string, object> Args = new Dictionary<string, object>
            {
                {"@id",employee.Id},
                {"@name",employee.Name},
                {"@sal",Convert.ToInt32(employee.Salary)}
            };
            if (employee.Manager != null)
                Args.Add("@mgr",employee.Manager.Id);
            _procedure.NoQuery("UpdateEmployee", Args);
        }

        public static void Delete(int id)
        {
            _procedure = new MySqlProcedure();
            Dictionary<string, object> Args = new Dictionary<string, object>
            {
                {"@id",id}
            };
            _procedure.NoQuery("DeleteEmployee", Args);
        }
    }
}
