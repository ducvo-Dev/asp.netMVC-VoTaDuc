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
using PagedList;
namespace ShopNongSan.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        ProductDAO catDAO = new ProductDAO();

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(catDAO.getList("Index"));
        }
        public ActionResult Trash()
        {
            return View(catDAO.getList("Trash"));
        }
        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = catDAO.getRow(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                product.Slug = MyString.Str_slug(product.Name);
                product.Created_At = DateTime.Now;
                //category.Created_By = int.Parse(Session["UserId"].ToString());
                product.Updated_At = DateTime.Now;
                //category.Updated_By = int.Parse(Session["UserId"].ToString());
          
                catDAO.Insert(product);
                return RedirectToAction("Index");
            }
           
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = catDAO.getRow(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Slug = MyString.Str_slug(product.Name);
                product.Updated_At = DateTime.Now;
                catDAO.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Product product = catDAO.getRow(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            return View(product);
            TempData["XMessage"] = new MyMessage("Xóa mẫu tin Thành công", "success");
            return RedirectToAction("Trash"); //chuyen huong trang về thùng rác
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Product product = catDAO.getRow(id);

            return RedirectToAction("Index");
        }
        //trang thai

        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Product product  = catDAO.getRow(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            product.Status = (product.Status == 1) ? 2 : 1;
            product.Updated_At = DateTime.Now;
            catDAO.Update(product);
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
            Product product = catDAO.getRow(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            product.Status = 0;
            product.Updated_At = DateTime.Now;
            catDAO.Update(product);
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
            Product product = catDAO.getRow(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            product.Status = 2;
            product.Updated_At = DateTime.Now;
            catDAO.Update(product);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }

    }
}