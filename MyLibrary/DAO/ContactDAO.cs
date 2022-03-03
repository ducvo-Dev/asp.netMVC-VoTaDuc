using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class ContactDAO       
    {
        private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        public List<Contact> getList(string page = "Index")// tra ve danh sach
        {
            if (page == "Index")
            {
                var list = db.Contacts
                        .Where(m => m.Status != 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }
            else
            {
                var list = db.Contacts
                        .Where(m => m.Status == 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }



        }
        public List<Contact> getList()// tra ve danh sach
        {
            var list = db.Contacts.ToList();
            return list;
        }

        public long getCount()// tra ve so luong
        {
            var count = db.Contacts.Count();
            return count;
        }

        public Contact getRow(int? id)// tra ve 1 mau tin
        {
            var row = db.Contacts.Find(id);
            return row;
        }

        public void Insert(Contact row)// them
        {
            {
                db.Contacts.Add(row);
                db.SaveChanges();

            }
        }
        public void Update(Contact row)// Sua
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Contact row)// Xoa
        {
            db.Contacts.Remove(row);
            db.SaveChanges();

        }

    }

}
