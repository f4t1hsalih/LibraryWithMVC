using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {
            return View();
        }
    }
}