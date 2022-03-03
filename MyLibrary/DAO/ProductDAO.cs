using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;
using PagedList;

namespace MyLibrary.DAO
{
    public class ProductDAO
    {
    
            private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc
        // phan trang
        public List<Product> getList(string page = "Index")// tra ve danh sach
        {
            if (page == "Index")
            {
                var list = db.Products
                        .Where(m => m.Status != 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }
            else
            {
                var list = db.Products
                        .Where(m => m.Status == 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }



        }
        public PagedList.IPagedList<Product> getList(int pageSize, int pageNumber)// tra ve danh sach
        {
            var list = db.Products
                .Where(m => m.Status == 1)
                .OrderByDescending(m => m.Created_At)
                .ToPagedList(pageNumber, pageSize);

            return list;
        }
        public List<Product> getList()// tra ve danh sach
        {
            var list = db.Products
                .Where(m => m.Status == 1 )
                .OrderByDescending(m => m.Created_At)
                .ToList();

            return list;
        }
      // lay san pham theo loai
        public List<Product> getList(List<int> listcatid,int limit )// tra ve danh sach
        {
            var list = db.Products
                .Where(m => m.Status == 1&& listcatid.Contains(m.Catid))
                .OrderByDescending(m=>m.Created_At)
                .Take(limit)
                .ToList();

            return list;
        }

        public List<Product> getList(List<int> listcatid, int limit,int not_id,bool check=true)// tra ve danh sach
        {
            var list = db.Products
                .Where(m => m.Status == 1&& m.Id!=not_id && listcatid.Contains(m.Catid))
                .OrderByDescending(m => m.Created_At)
                .Take(limit)
                .ToList();

            return list;
        }

        public PagedList.IPagedList<Product> getList(List<int> listcatid, int pageSize, int pageNumber)// tra ve danh sach
        {
            var list = db.Products
                .Where(m => m.Status == 1 && listcatid.Contains(m.Catid))
                .OrderByDescending(m => m.Created_At)

                 .ToPagedList(pageNumber, pageSize);

            return list;
        }

            public long getCount()// tra ve so luong
            {
                var count = db.Products.Count();
                return count;
            }

            public Product getRow(String slug)// tra ve 1 mau tin
            {
                var row = db.Products.Where(m => m.Slug == slug&& m.Status==1).FirstOrDefault() ;
            return row;
            }
            public Product getRow(int? id)// tra ve 1 mau tin
            {
                var row = db.Products.Find(id);
                return row;
            }


        public void Insert(Product row)// them
            {
                {
                    db.Products.Add(row);
                    db.SaveChanges();

                }
            }
            public void Update(Product row)// Sua
            {
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();

            }

            public void Delete(Product row)// Xoa
            {
                db.Products.Remove(row);
                db.SaveChanges();

            }
        }
    }

