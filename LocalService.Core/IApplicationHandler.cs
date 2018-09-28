using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
   public interface IApplicationHandler
    {
       void Execute(ApplicationContext context);
    }
}
