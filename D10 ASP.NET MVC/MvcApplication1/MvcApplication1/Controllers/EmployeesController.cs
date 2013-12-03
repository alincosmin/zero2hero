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
            return View(new EmployeesModels());
        }

        [HttpPost]
        public ActionResult Insert(EmployeesModels _emp)
        {
            if (ModelState.IsValid)
            {
                EmployeesModels.Add(_emp);
                return RedirectToAction("View");
            }
            return View(_emp);
        }

        public ActionResult View()
        {
            List<EmployeesModels> _list = EmployeesModels.GetAll();
            return View(_list);
        }

        public ActionResult Edit(int id)
        {
            EmployeesModels _emp = EmployeesModels.GetAll().Find(x => x.Id == id);
            if (_emp == null)
                return HttpNotFound();
            
            return View(_emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeesModels _emp)
        {
            if (ModelState.IsValid)
            {
                EmployeesModels.Edit(_emp);
                return RedirectToAction("View");
            }
            return View(_emp);
        }
    
        public ActionResult Delete(int id)
        {
            EmployeesModels _emp = EmployeesModels.GetAll().Find(x => x.Id == id);
            if (_emp == null)
                return HttpNotFound();
            return View(_emp);
        }

        [HttpPost]
        public ActionResult Delete(EmployeesModels _employee)
        {
            if (_employee == null)
                return View(_employee);
            EmployeesModels.Remove(_employee.Id);
            return RedirectToAction("View");
        }
    }
}
