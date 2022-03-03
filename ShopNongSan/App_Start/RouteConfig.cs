using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopNongSan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TrangChu",
                url: "trang-chu",
                defaults: new { controller = "Site", action = "Home", id = UrlParameter.Optional });


            routes.MapRoute(
               name: "TatCaSanPham",
               url: "san-pham",
               defaults: new { controller = "Site", action = "Product", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "TatCaBaiViet",
                url: "san-pham",
                defaults: new { controller = "Site", action = "Post", id = UrlParameter.Optional });
            
           
            routes.MapRoute(
                name: "LoaiSanPham",
                url: "san-pham/{slug}",
                defaults: new { controller = "SanPham", action = "ProdcutCategory", id = UrlParameter.Optional });

            //  url 1 cap
            routes.MapRoute(
                name: "SiteSlug",
                url: "{slug}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
