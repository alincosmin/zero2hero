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

    }
}
