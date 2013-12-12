using System.Collections.Generic;
using System.Reflection.Emit;
using System.Web.Mvc;
using FinallySomethingNew.Models;

namespace FinallySomethingNew.Controllers
{
    public class MotorcyclesController : Controller
    {
        //
        // GET: /Moto/
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult List()
        {
            return Json(MotoList.List(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(Moto motorcycle)
        {
            MotoList.Add(motorcycle);
            return Json(true);
        }

    }
}
