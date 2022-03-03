using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class LinkDAO
    {
        private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        public List<Link> getList(string page = "Index")// tra ve danh sach
        {
            if (page == "Index")
            {
                var list = db.Links
                        .Where(m => m.Status != 0)       
                        .ToList();
                return list;
            }
            else
            {
                var list = db.Links
                        .Where(m => m.Status == 0) 
                        .ToList();
                return list;
            }



        }
        public List<Link> getList()// tra ve danh sach
        {
            var list = db.Links.ToList();
            return list;
        }

        public long getCount()// tra ve so luong
        {
            var count = db.Links.Count();
            return count;
        }

        public Link getRow(String slug)// tra ve 1 mau tin
        {
            var row = db.Links.Where(m => m.Slug == slug).FirstOrDefault() ;
            return row;
        }

        public Link getRow(int? id)// tra ve 1 mau tin
        {
            var row = db.Links.Find(id);
            return row;
           
        }

        public void Insert(Link row)// them
        {
            {
                db.Links.Add(row);
                db.SaveChanges();

            }
        }
        public void Update(Link row)// Sua
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Link row)// Xoa
        {
            db.Links.Remove(row);
            db.SaveChanges();

        }

    }

}

