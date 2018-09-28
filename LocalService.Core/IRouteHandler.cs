using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
   public interface IRouteHandler
    {
       Route MapRoute(ApplicationContext context);
    }
}
