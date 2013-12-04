using EmployeesManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeesManagersMVC.Models
{
    public class EmployeeName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EList
    {
        public static List<EmployeeName> List(int eid)
        {
          EmployeeName _temp;
          List<EmployeeName> _list = new List<EmployeeName>();
          foreach(Employee E in StoreService.Store.EmpList)
          {
              if (E.Id == eid)
                  continue;
              _temp = new EmployeeName();
              _temp.Id = E.Id;
              _temp.Name = E.Name;
              _list.Add(_temp);
          }
          return _list;
        }
    }
}