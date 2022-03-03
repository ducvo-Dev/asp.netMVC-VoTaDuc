using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class PostDAO
    {
            private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc


        public List<Post> getList(string page = "Index")// tra ve danh sach
        {
            if (page == "Index")
            {
                var list = db.Posts
                        .Where(m => m.Status != 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }
            else
            {
                var list = db.Posts
                        .Where(m => m.Status == 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }



        }
        public List<Post> getList()// tra ve danh sach
        {
            var list = db.Posts.ToList();
            return list;
        }
        public List<Post> getList(int? topid,int limit,int notid)// tra ve danh sach
            {
            var list = db.Posts.Where(m => m.Topid == topid && m.Status == 1&&m.Id!=notid)
                .OrderByDescending(m=>m.Created_At)
                .Take(limit)
                .ToList();
            return list;
            }

            public long getCount()// tra ve so luong
            {
                var count = db.Posts.Count();
                return count;
            }
        public Post getRow(int? id)// tra ve 1 mau tin
        {
            var row = db.Posts.Find(id);
            return row;
        }
        public Post getRow(String slug)// tra ve 1 mau tin
            {
                var row = db.Posts.Where(m => m.Slug == slug && m.Status == 1).FirstOrDefault();
                return row;
            }

        public void Insert(Post row)// them
            {
                {
                    db.Posts.Add(row);
                    db.SaveChanges();

                }
            }
            public void Update(Post row)// Sua
            {
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();

            }

            public void Delete(Post row)// Xoa
            {
                db.Posts.Remove(row);
                db.SaveChanges();

            }
        }
    }

