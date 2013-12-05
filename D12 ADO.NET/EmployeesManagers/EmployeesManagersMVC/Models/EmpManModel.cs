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
        public static EmpManModel Find(int id)
        {
            EmpManModel _temp = null;
            Employee _temp2 = StoreService.Store.EmpList.Find(x => x.Id == id);
            if (_temp2 != null)
            {
                _temp = new EmpManModel();
                _temp.Id = _temp2.Id;
                _temp.Name = _temp2.Name;
                _temp.Salary = _temp2.Salary;
                if (_temp2.Manager != null)
                {
                    _temp.ManagerId = _temp2.Manager.Id;
                    _temp.ManagerName = _temp2.Manager.Name;
                } 
            }
            return _temp;
        }
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
                    if (emp.Manager != null)
                    {
                        _temp.ManagerId = emp.Manager.Id;
                        _temp.ManagerName = emp.Manager.Name;
                    }
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

        public static void Update(EmpManModel _employee)
        {
            Employee E = new Employee();
            E.Id = _employee.Id;
            E.Name = _employee.Name;
            E.Salary = _employee.Salary;
            if (_employee.ManagerId > 0)
                E.Manager = StoreService.Store.EmpList.Find(x => x.Id == _employee.ManagerId);
            StoreService.Store.Update(E);
        }

        public static void Delete(int id)
        {
            StoreService.Store.Delete(id);
        }
    }

    public class EmployeeName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EList
    {
        public static List<EmployeeName> List(int eid = 0)
        {
            EmployeeName _temp;
            List<EmployeeName> _list = new List<EmployeeName>();
            foreach (Employee E in StoreService.Store.EmpList)
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