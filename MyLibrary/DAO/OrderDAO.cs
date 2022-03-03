using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class OrderDAO
    {
        private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        public List<Order> getList()// tra ve danh sach
        {
            var list = db.Orders.ToList();
            return list;
        }

        public long getCount()// tra ve so luong
        {
            var count = db.Orders.Count();
            return count;
        }

        public Order getRow(int? id)// tra ve 1 mau tin
        {
            var row = db.Orders.Find(id);
            return row;
        }

        public void Insert(Order row)// them
        {
            {
                db.Orders.Add(row);
                db.SaveChanges();

            }
        }
        public void Update(Order row)// Sua
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Order row)// Xoa
        {
            db.Orders.Remove(row);
            db.SaveChanges();

        }
    }
}
