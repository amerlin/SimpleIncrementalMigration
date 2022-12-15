using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleIncrementalMigration.Controllers
{
    public class BikeController : Controller
    {
        // GET: Bike
        public ActionResult Index()
        {
            ViewBag.Message = TestLibrary.Class1.GetValue();
            return View();
        }
    }
}