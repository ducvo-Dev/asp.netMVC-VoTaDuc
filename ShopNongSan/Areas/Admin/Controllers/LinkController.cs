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
    public class LinkController : BaseController
    {
        LinkDAO catDAO = new LinkDAO();

        // GET: Admin/Link
        public ActionResult Index()
        {
            return View(catDAO.getList("Index"));
        }
        public ActionResult Trash()
        {
            return View(catDAO.getList("Trash"));
        }
        // GET: Admin/Link/Details/5
        public ActionResult Details(String slug)
        {
            if (slug == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = catDAO.getRow(slug);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // GET: Admin/Link/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Link/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Link link)
        {
            if (ModelState.IsValid)
            {
                catDAO.Insert(link);

                return RedirectToAction("Index");
            }

            return View(link);
        }

        // GET: Admin/Link/Edit/5
        public ActionResult Edit(String slug)
        {
            if (slug == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = catDAO.getRow(slug);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Admin/Link/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Link link)
        {
            if (ModelState.IsValid)
            {     
                catDAO.Update(link);

                return RedirectToAction("Index");
            }
            return View(link);
        }

        // GET: Admin/Link/Delete/5
        public ActionResult Delete(String slug)
        {
            if (slug == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Link link = catDAO.getRow(slug);
            if (link == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            catDAO.Delete(link);
            TempData["XMessage"] = new MyMessage("Xóa mẫu tin Thành công", "success");
            return RedirectToAction("Trash"); //chuyen huong trang về thùng rác
        }
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Link link = catDAO.getRow(id);
            if (link == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            link.Status = (link.Status == 1) ? 2 : 1;
            
            catDAO.Update(link);
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
            Link link = catDAO.getRow(id);
            if (link == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            link.Status = 0;
            catDAO.Update(link);
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
            Link link = catDAO.getRow(id);
            if (link == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            link.Status = 2;
            
            catDAO.Update(link);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }

    }
}
