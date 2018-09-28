using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
    public class RouteTable
    {
        Dictionary<string, Route> RouteDic = new Dictionary<string, Route>();
             

        public void Register(string name, string template, object defaults)
        {
            if (defaults == null)
            {
                throw new Exception("defaults not temp");
            }
            if (template == null)
            {
                throw new Exception("template not temp");
            }           

            if (!RouteDic.ContainsKey(name))
            {
                Route route = new Route()
                {
                    Template = template,
                    Defaults = defaults
                };
                RouteDic.Add(name, route);
            }
        }

        public Dictionary<string, Route> Routes {
            get {
                return RouteDic;
            }
        }
    }
}
