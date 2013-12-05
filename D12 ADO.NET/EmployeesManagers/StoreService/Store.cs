using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesManagers;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace StoreService
{
    public class Store
    {
        public static List<Employee> EmpList
        {
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
                    _temp.Name = (rdr["name"] != DBNull.Value)?(string)rdr["name"]:"";
                    _temp.Salary = (rdr["Salary"] != DBNull.Value)?Convert.ToInt32(rdr["Salary"]):0;
                    _list.Add(_temp);
                    pair[_temp.Id] = (rdr["mgr"] != DBNull.Value) ? Convert.ToInt32(rdr["mgr"]) : 0;
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
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EmpConnString"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fn",_emp.Name));
            cmd.Parameters.Add(new SqlParameter("@sal",Convert.ToInt32(_emp.Salary)));
            if (_emp.Manager != null)
                cmd.Parameters.Add(new SqlParameter("@mgr",_emp.Manager.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Update(Employee _emp)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EmpConnString"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", _emp.Id));
            cmd.Parameters.Add(new SqlParameter("@name", _emp.Name));
            cmd.Parameters.Add(new SqlParameter("@sal", Convert.ToInt32(_emp.Salary)));
            if (_emp.Manager != null)
                cmd.Parameters.Add(new SqlParameter("@mgr", _emp.Manager.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EmpConnString"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
