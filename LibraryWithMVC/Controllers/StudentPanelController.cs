using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    [Authorize]
    public class StudentPanelController : Controller
    {
        // GET: StudentPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}