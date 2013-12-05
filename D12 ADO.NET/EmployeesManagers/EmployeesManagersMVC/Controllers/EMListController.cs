using EmployeesManagersMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesManagersMVC.Controllers
{
    public class EMListController : Controller
    {
        //
        // GET: /EmployeesManagersList/

        public ActionResult New()
        {
            return View(new EmpManModel());
        }

        [HttpPost]
        public ActionResult New(EmpManModel _emp)
        {
            if (ModelState.IsValid)
            {
                EMList.Add(_emp);
                return RedirectToAction("List");
            }
            return View(_emp);
        }

        public ActionResult List()
        {
            return View(EMList.List);
        }

        public ActionResult ListEmps(int id = 0)
        {
            return View(EList.List(id));
        }

        public ActionResult Edit(int id)
        {
            EmpManModel _emp = EMList.Find(id);
            if (_emp == null)
                return HttpNotFound();
            return View(_emp);
        }

        [HttpPost]
        public ActionResult Edit(EmpManModel _emp)
        {
            if (ModelState.IsValid)
            {
                EMList.Update(_emp);
                return RedirectToAction("List");
            }
            return View(_emp);
        }

        public ActionResult Delete(int id)
        {
            EmpManModel _emp = EMList.Find(id);
            if (_emp == null)
                return HttpNotFound();
            return View(_emp);
        }

        [HttpPost]
        public ActionResult Delete(EmpManModel _emp)
        {
            EMList.Delete(_emp.Id);
            return RedirectToAction("List");
        }
    }
}
