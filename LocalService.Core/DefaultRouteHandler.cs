using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
   public class DefaultRouteHandler:IRouteHandler
    {
        public Route MapRoute(ApplicationContext context)
        {
            var url = context.HttpContext.Request.RawUrl;

            //  /ticket/print/?id =123

            var paths = url.Split('/');
            var contrllerName = "";
            var actionName = "";
            var id = "";
            if (paths.Length >= 2) {
                contrllerName = paths[0];
                actionName = paths[1];        
            }

            //  {controller}/{action}/id
            return null;
        }
    }
}
