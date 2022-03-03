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
    public class TopicController : BaseController
    {
        TopicDAO catDAO = new TopicDAO();

        // GET: Admin/Topic
        public ActionResult Index()
        {
            return View(catDAO.getList("Index"));
        }
        public ActionResult Trash()
        {
            return View(catDAO.getList("Trash"));
        }
        // GET: Admin/Topic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = catDAO.getRow(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: Admin/Topic/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(catDAO.getList("Index"), "Orders", "Name", 0);
            return View();
        }

        // POST: Admin/Topic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                topic.Slug = MyString.Str_slug(topic.Name);
                topic.Created_At = DateTime.Now;
                //category.Created_By = int.Parse(Session["UserId"].ToString());
                topic.Updated_At = DateTime.Now;
                catDAO.Insert(topic);
                return RedirectToAction("Index");
            }

            return View(topic);
        }

        // GET: Admin/Topic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = catDAO.getRow(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(catDAO.getList("Index"), "Orders", "Name", 0);
            return View(topic);
        }

        // POST: Admin/Topic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Topic topic)
        {
            if (ModelState.IsValid)
            {
                topic.Slug = MyString.Str_slug(topic.Name);
                topic.Updated_At = DateTime.Now;
                topic.Updated_At = DateTime.Now;
                catDAO.Update(topic);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(catDAO.getList("Index"), "Orders", "Name", 0);
            return View(topic);
        }

        // GET: Admin/Topic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Topic topic = catDAO.getRow(id);
            if (topic == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            catDAO.Delete(topic);
            TempData["XMessage"] = new MyMessage("Xóa mẫu tin Thành công", "success");
            return RedirectToAction("Trash"); //chuyen huong trang về thùng rá
        }

        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Topic topic = catDAO.getRow(id);
            if (topic == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            topic.Status = (topic.Status == 1) ? 2 : 1;
            topic.Updated_At = DateTime.Now;
            catDAO.Update(topic);
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
            Topic topic = catDAO.getRow(id);
            if (topic == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            topic.Status = 0;
            topic.Updated_At = DateTime.Now;
            catDAO.Update(topic);
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
            Topic topic = catDAO.getRow(id);
            if (topic == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            topic.Status = 2;
            topic.Updated_At = DateTime.Now;
            catDAO.Update(topic);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }
    }
}
