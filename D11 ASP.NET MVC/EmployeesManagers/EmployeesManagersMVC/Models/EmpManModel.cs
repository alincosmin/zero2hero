using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesManagers;

namespace EmployeesManagersMVC.Models
{
    public class EmpManModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Salary")]
        public double Salary { get; set; }

        [HiddenInput]
        public int ManagerId { get; set; }

        [Display(Name="Manager")]
        public string ManagerName { get; set; }
    }

    public class EMList
    {
        public static List<EmpManModel> List
        {
            get
            {
                EmpManModel _temp;
                List<EmpManModel> _list = new List<EmpManModel>();
                foreach(Employee emp in StoreService.Store.EmpList)
                {
                    _temp = new EmpManModel();
                    _temp.Id = emp.Id;
                    _temp.Name = emp.Name;
                    _temp.Salary = emp.Salary;
                    emp.Manager = new Employee();
                    _temp.ManagerId = emp.Manager.Id;
                    _temp.ManagerName = emp.Manager.Name;
                    _list.Add(_temp);
                }
                return _list;
            }

        }

        public static void Add(EmpManModel _employee)
        {
            Employee E = new Employee();
            E.Name = _employee.Name;
            E.Salary = _employee.Salary;
            if (_employee.ManagerId > 0)
                E.Manager = StoreService.Store.EmpList.Find(x => x.Id == _employee.ManagerId);
            StoreService.Store.Add(E);
        }
    }
}