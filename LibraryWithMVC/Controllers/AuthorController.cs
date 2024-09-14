using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                return View(db.tbl_author.Where(x => x.ath_status == true).ToList());
            }
        }

        // GET: Add Author
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(tbl_author author)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                ModelState.Remove("ath_id");
                if (ModelState.IsValid)
                {
                    author.ath_status = true;
                    db.tbl_author.Add(author);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(author);
                }

            }
        }

        // GET: Delete Author
        public ActionResult DeleteAuthor(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var author = db.tbl_author.Find(id);

                // Yazara ait aktif (iade edilmemiş) kitapları kontrol et
                bool hasActiveBooks = db.tbl_book.Any(b => b.bk_ath == id && b.bk_status == true);

                if (hasActiveBooks)
                {
                    // Kitap varsa, silme işlemi yapılmaz ve bir mesaj ile geri dönülür
                    TempData["ErrorMessage"] = "Bu yazarın aktif olarak kitapları olduğu için silinemez.";
                    return RedirectToAction("Index");
                }

                author.ath_status = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        // GET: Edit Author
        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                tbl_author author = db.tbl_author.Where(x => x.ath_status == true).FirstOrDefault(x => x.ath_id == id);
                return View(author);
            }
        }
        [HttpPost]
        public ActionResult EditAuthor(tbl_author author)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                ModelState.Remove("ath_id");
                if (ModelState.IsValid)
                {
                    db.Entry(author).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return View(author);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AuthorBooks(int id)
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            var author = db.tbl_author.Where(x => x.ath_id == id && x.ath_status == true).FirstOrDefault();
            ViewBag.Author = author.ath_name + " " + author.ath_surname;
            var values = db.tbl_book.Where(x => x.bk_ath == id && x.bk_status == true).ToList();
            return View(values);
        }

    }
}