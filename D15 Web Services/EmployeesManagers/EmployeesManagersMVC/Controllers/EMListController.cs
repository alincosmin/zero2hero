﻿using EmployeesManagersMVC.Models;
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
            EMList.Add(_emp);
            return RedirectToAction("List");
        }

        public ActionResult List(int pageId = 0)
        {
            
            return View(EMList.List);
        }

        public ActionResult ListEmps(int id = 0)
        {
            return View(EList.List(id));
        }

        public ActionResult ListCities()
        {
            return View(CList.List);
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
            EMList.Update(_emp);
            return RedirectToAction("List");
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
