using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core.Controllers
{
   public class HomeController:IController
    {
        public Models.ResultModel handler(string data)
        {
            return Models.ResultModel.Ok("Hello local service !");
        }
    }
}
