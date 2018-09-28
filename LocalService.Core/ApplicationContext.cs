using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
    public class ApplicationContext
    {

       
        HttpListenerContext _requestContext;
        Dictionary<string, IController> _routes;
        public ApplicationContext(HttpListenerContext requestContext, Dictionary<string, IController> routes)
        {
            
            _requestContext = requestContext;
            _routes = routes;
        }

        /// <summary>
        /// 初始化默认路由
        /// </summary>
        public Dictionary<string, IController> Routes
        {
            get {
                return this._routes;
            }
        }

        public HttpListenerContext HttpContext {
            get {
                return this._requestContext;
            }
        }
    }
}
