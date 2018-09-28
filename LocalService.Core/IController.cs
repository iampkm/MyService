using LocalService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
   public interface IController
    {
       ResultModel handler(string data);
    }
}
