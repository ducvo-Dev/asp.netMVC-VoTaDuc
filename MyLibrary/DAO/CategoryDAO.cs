﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class CategoryDAO
    {
        private NongSanDBContext db = new NongSanDBContext();

        // 6 ten phuong thuc

        public List<Category> getList(string page = "Index")// tra ve danh sach
        {
            if (page == "Index")
            {
                var list = db.Categorys
                        .Where(m =>  m.Status != 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }
            else
            {
                var list = db.Categorys
                        .Where(m => m.Status == 0)
                        .OrderBy(m => m.Created_At)
                        .ToList();
                return list;
            }


            
        }
        public List<Category> getList(int? parentid = 0)// tra ve danh sach
        {
            var list = db.Categorys
                .Where(m => m.Parenid == parentid && m.Status == 1)
                .OrderBy(m => m.Orders)
                .ToList();

            return list;
        }
        public List<Category> getList()// tra ve danh sach
        {
            var list = db.Categorys.ToList();
            return list;
        }

        public long getCount()// tra ve so luong
        {
            var count = db.Categorys.Count();
            return count;
        }

        public Category getRow(string slug)// tra ve 1 mau tin
        {
            var row = db.Categorys
                .Where(m => m.Slug == slug && m.Status == 1)
                .FirstOrDefault();
            return row;
        }
        public Category getRow(int? id)// tra ve 1 mau tin
        {
            var row = db.Categorys.Find(id);
            return row;
        }

        public void Insert(Category row)// them
        {

            db.Categorys.Add(row);
            db.SaveChanges();


        }
        public void Update(Category row)// Sua
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Category row)// Xoa
        {
            db.Categorys.Remove(row);
            db.SaveChanges();

        }

        public List<int> getListId(int parentid)
        {
            List<int> listcatid = new List<int>();
            List<Category> listcategory1 = this.getList(parentid);
            if (listcategory1.Count > 0)
            {
                foreach (var cat1 in listcategory1)
                {
                    listcatid.Add(cat1.Id);
                    List<Category> listcategory2 = this.getList(cat1.Id);
                    if (listcategory2.Count > 0)
                    {
                        foreach (var cat2 in listcategory2)
                        {
                            listcatid.Add(cat2.Id);
                            List<Category> listcategory3 = this.getList(cat2.Id);
                            if (listcategory3.Count > 0)
                            {
                                foreach (var cat3 in listcategory3)
                                {
                                    listcatid.Add(cat3.Id);
                                }
                            }
                        }
                    }
                }

            }
            listcatid.Add(parentid);
            return listcatid;
        }
    }
}