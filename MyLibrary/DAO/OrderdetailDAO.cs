using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class OrderdetailDAO
    {
        private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        public List<Orderdetail> getList()// tra ve danh sach
        {
            var list = db.Orderdetails.ToList();
            return list;
        }

        public long getCount()// tra ve so luong
        {
            var count = db.Orderdetails.Count();
            return count;
        }

        public Orderdetail getRow(int? id)// tra ve 1 mau tin
        {
            var row = db.Orderdetails.Find(id);
            return row;
        }

        public void Insert(Orderdetail row)// them
        {
            {
                db.Orderdetails.Add(row);
                db.SaveChanges();

            }
        }
        public void Update(Orderdetail row)// Sua
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Orderdetail row)// Xoa
        {
            db.Orderdetails.Remove(row);
            db.SaveChanges();

        }
    }
}
