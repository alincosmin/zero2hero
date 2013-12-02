using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class EmployeesController : Controller
    {
        //
        // GET: /Employees/
        
        public ActionResult Insert()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Insert(EmployeesModels employeeModel)
        //{
        //    EmployeesModels _emp = new EmployeesModels();
        //    if (ModelState.IsValid)
        //    {
        //        _emp.Name = employeeModel.Name;
        //        _emp.Salary = employeeModel.Salary;
        //        EmployeesModels.Add(_emp);
        //    }
                
        //    return View();
        //}

        public ActionResult View()
        {
            List<EmployeesModels> _list = EmployeesModels.GetAll();
            return View(_list);
        }
    }
}
