using LocalService.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteTable routes)
        //{
        //    routes.Register(
        //        name: "default",
        //        template: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Ticket", action = "print", id = "" }
        //        );
        //}

        /// <summary>
        ///  配置路由，url 请配置为小写
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(Dictionary<string,IController> routes)
        {
            routes.Add("/hello", new HomeController());
            routes.Add("/ticket/print", new TicketController());
           
        }
    }
}
