using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class MenuDAO
    {
        private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        public List<Menu> getList(int? parentid=0, string position="mainmenu")// tra ve danh sach
        {
            var list = db.Menus
                .Where(m => m.Position == position && m.Status == 1&&m.Parentid==parentid)
                .OrderBy(m=>m.Orders)
                .ToList();

            return list;
        }
        public List<Menu> getList(int parentid)// tra ve danh sach
        {
            var list = db.Menus
                .Where(m => m.Parentid == parentid && m.Status == 1)
                .ToList();

            return list;
        }

        public List<Menu> getList()// tra ve danh sach
        {
            var list = db.Menus.ToList();
            return list;
        }

        public long getCount()// tra ve so luong
        {
            var count = db.Menus.Count();
            return count;
        }
        public Menu getRow(String link)// tra ve 1 mau tin
        {
            var row = db.Menus.Where(m => m.Link == link).FirstOrDefault();

            return row;
        }
        public Menu getRow(int? id)// tra ve 1 mau tin
        {
            var row = db.Menus.Find(id);
            return row;
        }

        public void Insert(Menu row)// them
        {
            {
                db.Menus.Add(row);
                db.SaveChanges();

            }
        }
        public void Update(Menu row)// Sua
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Menu row)// Xoa
        {
            db.Menus.Remove(row);
            db.SaveChanges();

        }

    
}
}
