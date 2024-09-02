﻿using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                return View(db.tbl_category.ToList());
            }
        }

        // GET: AddCategory
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(tbl_category category)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.tbl_category.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: DeleteCategory
        public ActionResult DeleteCategory(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                tbl_category category = db.tbl_category.Find(id);
                db.tbl_category.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: EditCategory
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                tbl_category category = db.tbl_category.Find(id);
                return View(category);
            }
        }
        [HttpPost]
        public ActionResult EditCategory(tbl_category category)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}