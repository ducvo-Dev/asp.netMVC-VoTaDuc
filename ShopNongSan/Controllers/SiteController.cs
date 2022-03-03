using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Model;
using MyLibrary.DAO;
using System.Data.Entity;
using PagedList;



namespace ShopNongSan.Controllers
{
    public class SiteController : Controller
    {     

        LinkDAO linkDAO = new LinkDAO();
        ProductDAO productDAO = new ProductDAO();
        PostDAO postDAO = new PostDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        TopicDAO topicDAO = new TopicDAO();
        // GET: Site
        public ActionResult Index(String slug = "",int? page=1)
        {
            if (slug == "")
            {
                return this.Home();
            }
            else
            {
                Link row_link = linkDAO.getRow(slug);
                if (row_link != null)
                {
                    string typelink = row_link.TypeLink;
                    switch (typelink)
                    {
                        case "category": { return this.ProdcutCategory(slug,page); }
                        case "topic": { return this.PostTopic(slug); }
                        case "page": { return this.PostPage(slug); }
                    }
                }
                else
                {
                    if (productDAO.getRow(slug) != null)
                    {
                        return this.ProdcutDetail(slug);
                    }
                    if (postDAO.getRow(slug) != null)
                    {
                        return this.PostDetail(slug);
                    }
                    return this.Error404(slug);
                }   
            }
            return this.Error404(slug);
        }
        public ActionResult Home()
        {
            var listCategory = categoryDAO.getList(0);
            return View("Home", listCategory);
        }
        public ActionResult ProductHome(int catid, string name, String slug, int? page)
        {
            int pageSize = 4;
            int pageNumber = page ?? 1;
            ViewBag.NameCat = name;
            List<int> listcatid = categoryDAO.getListId(catid);
           
            var list = productDAO.getList(listcatid, pageSize, pageNumber);
            return View("ProductHome", list);
        }
        public ActionResult Product(int? page)
        {
            int pageSize = 12;
            int pageNumber = page??1;
            
            var list = productDAO.getList(pageSize,pageNumber);
            return View("Product",list);
        }

        public ActionResult ProdcutCategory(String slug, int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;
     
            var row_cat = categoryDAO.getRow(slug);
            int catid = row_cat.Id;
            List<int> listcatid = categoryDAO.getListId(catid);
            var list = productDAO.getList(listcatid, pageSize, pageNumber);
            ViewBag.Slug = slug;
            ViewBag.Title = row_cat.Name;
            return View("ProdcutCategory",list);
        }



        public ActionResult ProdcutDetail(String slug)
        {
            int limit = 8;
            var row = productDAO.getRow(slug);
            int catid = row.Catid;
            List<int> listcatid = categoryDAO.getListId(catid);
            var listother = productDAO.getList(listcatid,limit,row.Id,true);
            ViewBag.ListOther = listother;
            return View("ProdcutDetail",row);
        }

        public ActionResult Post()
        {
            return View("Post");
        }
        public ActionResult PostTopic(String slug)
        {
            var row_topic = topicDAO.getRow(slug);
            ViewBag.Title = row_topic.Name;
            int topicid = row_topic.Id;
            return View("PostTopic");
        }
        public ActionResult PostDetail(String slug)
        {
            int limit = 10;
            var row = postDAO.getRow(slug);
            int? topid = row.Topid;
            ViewBag.ListOther = postDAO.getList(topid,limit,row.Id) ;
            return View("PostDetail",row);
        }
        public ActionResult PostPage(String slug)
        {
            var row = postDAO.getRow(slug);
            return View("PostPage",row);
        }
        public ActionResult Error404(String slug)
        {
            return View("Error404");
        }
    }
}