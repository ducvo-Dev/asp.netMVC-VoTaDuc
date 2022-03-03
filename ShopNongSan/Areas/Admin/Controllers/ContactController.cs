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
    public class ContactController : BaseController
    {
        ContactDAO contactDAO = new ContactDAO();

        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View(contactDAO.getList("Index"));
        }

        public ActionResult Trash()
        {
            return View(contactDAO.getList("Trash"));
        }
        // GET: Admin/Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactDAO.getRow(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Admin/Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Contact contact)
        {
            if (ModelState.IsValid)
            {
               
                contact.Created_At = DateTime.Now;
                //category.Created_By = int.Parse(Session["UserId"].ToString());
                contact.Updated_At = DateTime.Now;

                contactDAO.Insert(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Admin/Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactDAO.getRow(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Contact contact)
        {
            if (ModelState.IsValid)
            {
                
                contact.Updated_At = DateTime.Now;
                contactDAO.Update(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Admin/Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang;
            }
            Contact contact = contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            contactDAO.Delete(contact);
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
            Contact contact = contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            contact.Status = (contact.Status == 1) ? 2 : 1;
            contact.Updated_At = DateTime.Now;
            contactDAO.Update(contact);
            TempData["XMessage"] = new MyMessage("Thay đổi trạng thái Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }
        public ActionResult Deltrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            Contact contact = contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            contact.Status = 0;
            contact.Updated_At = DateTime.Now;
            contactDAO.Update(contact);
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
            Contact contact = contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index"); //chuyen huong trang
            }
            contact.Status = 2;
            contact.Updated_At = DateTime.Now;
            contactDAO.Update(contact);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin Thành công", "success");
            return RedirectToAction("Index"); //chuyen huong trang
        }
    }
}
