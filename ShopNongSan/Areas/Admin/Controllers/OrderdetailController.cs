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
    public class OrderdetailController : BaseController
    {
        OrderdetailDAO catDAO = new OrderdetailDAO();

        // GET: Admin/Orderdetail
        public ActionResult Index()
        {
            return View(catDAO.getList());
        }

        // GET: Admin/Orderdetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderdetail orderdetail = catDAO.getRow(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        // GET: Admin/Orderdetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Orderdetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Orderid,Productid,Price,Quantity,Amount")] Orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                catDAO.Insert(orderdetail);
                return RedirectToAction("Index");
            }

            return View(orderdetail);
        }

        // GET: Admin/Orderdetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderdetail orderdetail = catDAO.getRow(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        // POST: Admin/Orderdetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
               
                catDAO.Update(orderdetail);
                return RedirectToAction("Index");
            }
            return View(orderdetail);
        }

        // GET: Admin/Orderdetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderdetail orderdetail = catDAO.getRow(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        // POST: Admin/Orderdetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orderdetail orderdetail = catDAO.getRow(id);

            return RedirectToAction("Index");
        }

    }
}
