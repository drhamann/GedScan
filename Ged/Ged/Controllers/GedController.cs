using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ged.Controllers
{
    public class GedController : Controller
    {
        // GET: Ged
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddContent()
        {
            return PartialView();
        }
    }
}