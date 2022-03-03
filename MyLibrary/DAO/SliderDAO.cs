using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class SliderDAO
    {
        
            private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        public List<Slider> getList(string position="slideshow")// tra ve danh sach
        {
            var list = db.Sliders
                .Where(m => m.Position == position && m.Status == 1)
                .OrderBy(m=>m.Orders)
                .ToList();
            return list;
        }
        public List<Slider> getList()// tra ve danh sach
            {
                var list = db.Sliders.ToList();
                return list;
            }

            public long getCount()// tra ve so luong
            {
                var count = db.Sliders.Count();
                return count;
            }
        public Slider getRow(String position)// tra ve 1 mau tin
        {
            var row = db.Sliders.Where(m => m.Position == position).FirstOrDefault();

            return row;
        }
        public Slider getRow(int? id)// tra ve 1 mau tin
            {
                var row = db.Sliders.Find(id);
                return row;
            }

            public void Insert(Slider row)// them
            {
                {
                    db.Sliders.Add(row);
                    db.SaveChanges();

                }
            }
            public void Update(Slider row)// Sua
            {
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();

            }

            public void Delete(Slider row)// Xoa
            {
                db.Sliders.Remove(row);
                db.SaveChanges();

            }
        }
    }
