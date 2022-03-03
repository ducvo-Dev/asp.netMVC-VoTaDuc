using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class TopicDAO
    {
            private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        public List<Topic> getList(string page = "Index")// tra ve danh sach
        {
            if (page == "Index")
            {
                var list = db.Topics
                        .Where(m => m.Status != 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }
            else
            {
                var list = db.Topics
                        .Where(m => m.Status == 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }



        }
        public List<Topic> getList()// tra ve danh sach
            {
                var list = db.Topics.ToList();
                return list;
            }

            public long getCount()// tra ve so luong
            {
                var count = db.Topics.Count();
                return count;
            }

            public Topic getRow(int? id)// tra ve 1 mau tin
            {
                var row = db.Topics.Find(id);
                return row;
            }
        public Topic getRow(String slug)// tra ve 1 mau tin
        {
            var row = db.Topics.Where(m => m.Slug == slug && m.Status == 1).FirstOrDefault();
            return row;
        }

        public void Insert(Topic row)// them
            {
                {
                    db.Topics.Add(row);
                    db.SaveChanges();

                }
            }
            public void Update(Topic row)// Sua
            {
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();

            }

            public void Delete(Topic row)// Xoa
            {
                db.Topics.Remove(row);
                db.SaveChanges();

            }
        }
    }

