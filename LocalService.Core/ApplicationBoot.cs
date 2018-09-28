using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
namespace LocalService.Core
{
   public class ApplicationBoot
    {
      static HttpListener _httpListener;
      static bool _runing = false;


       /// <summary>
       ///  启动服务
       /// </summary>
       public static void Start()
       {
           try
           {

               // "http://localhost:20020/"
               var url =ConfigurationManager.AppSettings["host"];
               _httpListener = new HttpListener();
               _httpListener.Prefixes.Add(url);
               _httpListener.Start(); 
               _runing = true;
               Console.WriteLine("服务已启动");     
           }
           catch (Exception ex)
           {
               var err = "启动本地服务器出现问题：" + ex.Message;
               Console.WriteLine(err);
           }
           //RouteTable routeTable = new RouteTable();
           //RouteConfig.RegisterRoutes(routeTable); // 注册路由

           // 简单注册路由
           Dictionary<string, IController> routeTable = new Dictionary<string, IController>();
           RouteConfig.RegisterRoutes(routeTable); 

           while (_runing) {
               HttpListenerContext requestContext = _httpListener.GetContext();
               Console.WriteLine("request:{0}",requestContext.Request.RawUrl);     
               Task.Factory.StartNew(() => {
                   IApplicationHandler hander = new DefaultHandler();
                   hander.Execute(new ApplicationContext(requestContext,routeTable));
               });
           }
       }

       /// <summary>
       ///  停止服务
       /// </summary>
       public static void Stop()
       {
           try
           {
               _runing = false;
               _httpListener.Stop();
           }
           catch (Exception ex)
           {               
               throw new Exception("服务停止失败"+ex.Message);
           }          
       }
    }
}
