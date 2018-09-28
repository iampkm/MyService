using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalService.Core.Controllers;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using LocalService.Core.Models;
namespace LocalService.Core
{
    public class DefaultHandler : IApplicationHandler
    {
        public void Execute(ApplicationContext context)
        {
            if (context == null) throw new Exception("请求为空");

            var url = context.HttpContext.Request.RawUrl;
            Console.WriteLine("rawUrl:{0}", context.HttpContext.Request.RawUrl);
            Console.WriteLine("UserHostAddress:{0}", context.HttpContext.Request.UserHostAddress);
            Console.WriteLine("UserHostName:{0}", context.HttpContext.Request.UserHostName);
            Console.WriteLine("UserAgent:{0}", context.HttpContext.Request.UserAgent);
                        
            // 查找路由
             var result = "";
             if (context.Routes.ContainsKey(url.ToLower()))
             {
                 //1 解析提交的json 数据
                 var req = context.HttpContext.Request;
                 var data = "";
                 using (var r = new StreamReader(req.InputStream, Encoding.UTF8))
                 {
                     data = r.ReadToEnd();
                 }

                 var controller = context.Routes[url];
                 result = Newtonsoft.Json.JsonConvert.SerializeObject(controller.handler(data));
             }
             else
             {
                 result = Newtonsoft.Json.JsonConvert.SerializeObject(ResultModel.Error(string.Format("请求地址未找到:{0}", url)));
             }
             //4 包装返回结果
             Console.WriteLine("response:{0}",result);
             Respose(context.HttpContext.Response, result);

        }

        private void Respose(HttpListenerResponse response, string jsonStr = "")
        {
            byte[] buffer = Encoding.UTF8.GetBytes(jsonStr); 
            response.ContentLength64 = buffer.Length; 
            response.ContentType = "application/json"; 
            response.ContentEncoding = Encoding.UTF8; 
            response.StatusCode = 200;
            response.Headers.Add("Access-Control-Allow-Origin", "*");//允许浏览器跨域！非常重要
            Stream output = response.OutputStream; 
            output.Write(buffer, 0, buffer.Length);
            //关闭输出流，释放相应资源           
            output.Close();
            response.Close();
        }

        


    }
}
