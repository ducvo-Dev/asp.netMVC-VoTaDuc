using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
   public class UserDAO
    {   
            private NongSanDBContext db = new NongSanDBContext();

            // 6 ten phuong thuc
            public List<User> getList()// tra ve danh sach
            {
                var list = db.Users.ToList();
                return list;
            }

            public long getCount()// tra ve so luong
            {
                var count = db.Users.Count();
                return count;
            }
        public User getRow(string username)// tra ve 1 mau tin
        {
            var row = db.Users
                .Where(m => m.Access==1 && m.Status== 1 && (m.Username == username ||m.email==username))
                .FirstOrDefault();
            return row;
        }
        public User getRow(int? id)// tra ve 1 mau tin
            {
                var row = db.Users.Find(id);
                return row;
            }

            public void Insert(User row)// them
            {
                {
                    db.Users.Add(row);
                    db.SaveChanges();

                }
            }
            public void Update(User row)// Sua
            {
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();

            }

            public void Delete(User row)// Xoa
            {
                db.Users.Remove(row);
                db.SaveChanges();

            }
        }
 }