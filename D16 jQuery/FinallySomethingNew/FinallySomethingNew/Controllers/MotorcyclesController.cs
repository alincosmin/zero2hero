using System.Collections.Generic;
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
            Moto moto = null;
            if (MotoList.List == null)
            {
                MotoList.List = new List<Moto>();
                moto = new Moto();
                moto.Brand = "Suzuki";
                moto.Model = "GSX-R 750";
                moto.Year = 2007;
                moto.Image = "";
                MotoList.List.Add(moto);
            }
            return Json(MotoList.List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(Moto motorcycle)
        {
            if (MotoList.List == null)
                MotoList.List = new List<Moto>();
            MotoList.List.Add(motorcycle);
            return Json(true);
        }

    }
}
