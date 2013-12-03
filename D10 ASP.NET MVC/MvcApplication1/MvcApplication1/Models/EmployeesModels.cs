using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class EmployeesModels
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Salary")]
        public double Salary { get; set; }   

        public static List<EmployeesModels> GetAll()
        {
            List<EmployeesModels> _list = (List<EmployeesModels>)HttpContext.Current.Session["Employees"];
            if (_list == null)
            {
                _list = new List<EmployeesModels>();
                HttpContext.Current.Session["Employees"] = _list;
            }
            return _list; 
        }

        public static void Add(EmployeesModels _employee)
        {
          List<EmployeesModels> _list = EmployeesModels.GetAll();
          Random rnd = new Random();
          int id = rnd.Next(1, 100);
          while (_list.Find(x => x.Id == id) != null)
              id = rnd.Next(1, 100);
          _employee.Id = id;
          _list.Add(_employee);
          HttpContext.Current.Session["Employees"] = _list;
        }

        public static void Edit(EmployeesModels _employee)
        {
            EmployeesModels _emp = EmployeesModels.GetAll().Find(x => x.Id == _employee.Id);
            _emp.Name = _employee.Name;
            _emp.Salary = _employee.Salary;
        }

        public static void Remove(int id)
        {
            List<EmployeesModels> _list = EmployeesModels.GetAll();
            _list.Remove(_list.Find(x => x.Id == id));
            HttpContext.Current.Session["Employees"] = _list;
        }
    }
 
}