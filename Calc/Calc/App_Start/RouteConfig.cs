using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Calc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Создаем правила для нашего проекта
            routes.MapRoute(
                 "Home-Calc",
                 "",
                 new { controller="Home", action="Calc"}
                 );
             routes.MapRoute(
                 "Home-Result",
                 "Home/Result.aspx",
                 new { controller = "Home", action = "Result" } //Правило для обработки результата
                 );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        
    }
}