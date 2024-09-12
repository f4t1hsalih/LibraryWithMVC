using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            int id = (int)Session["id"];
            var values = db.tbl_message.Where(x => x.msg_recipient == id).ToList();
            return View(values);

        }

        public ActionResult NewMessage()
        {
            return RedirectToAction("Index");
        }
    }
}