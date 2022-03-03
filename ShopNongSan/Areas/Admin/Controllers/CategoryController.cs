using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Model;
using MyLibrary.DAO;

namespace ShopNongSan.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        
        CategoryDAO catDAO = new CategoryDAO();

        // GET: Admin/Category
        public ActionResult Index()
        {
 
            return View(catDAO.getList("Index"));
        }

        public ActionResult Trash()
        {
            return View(catDAO.getList("Trash"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = catDAO.getRow(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(catDAO.getList("Index"), "Orders", "Name", 0);
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = MyString.Str_slug(category.Name);
                category.Created_At = DateTime.Now;
                //category.Created_By = int.Parse(Session["UserId"].ToString());
                category.Updated_At = DateTime.Now;
                //category.Updated_By = int.Parse(Session["UserId"].ToString());
                catDAO.Insert(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = catDAO.getRow(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(catDAO.getList("Index"), "Orders", "Name", 0);
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = MyString.Str_slug(category.Name);
                category.Updated_At = DateTime.Now; 
                catDAO.Update(category);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(catDAO.getList("Index"), "Orders", "Name", 0);
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Category category = catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            catDAO.Delete(category);
            TempData["XMessage"] = new MyMessage("Xóa mẫu tin Thành công", "success");
            return RedirectToAction("Trash"); //chuyen huong trang về thùng rác
        }

        //trang thai

        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Category category = catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            category.Status = (category.Status == 1) ? 2 : 1;
            category.Updated_At = DateTime.Now; 
            catDAO.Update(category);
            TempData["XMessage"] = new MyMessage("Thay đổi trạng thái Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }

        //Xoa vao thung rac

        public ActionResult Deltrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Category category = catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            category.Status = 0;
            category.Updated_At = DateTime.Now;
            catDAO.Update(category);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }

        //Khoi phục mau tin

        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Category category = catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            category.Status = 2;
            category.Updated_At = DateTime.Now;
            catDAO.Update(category);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }
    }
}
