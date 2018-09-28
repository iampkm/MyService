using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core.Models
{
   public class ResultModel
    {
       public int code { get; private set; }

       public bool success { get; private set; }

       public string message { get; private set; }

       public object data { get; private set; }


       private ResultModel(int code, bool success, string message, object data)
       {
           this.code = code;
           this.success = success;
           this.message = message;
           this.data = data;
       }

       public static ResultModel Ok()
       {
           return new ResultModel(200, true, "success", "");
       }      
       public static ResultModel Ok(object data)
       {
           return new ResultModel(200, true, "success", data);
       }
       public static ResultModel Ok(string message,object data)
       {
           return new ResultModel(200, true, message, data);
       }

       public static ResultModel Error(string message)
       {
           return new ResultModel(500, false, message, "");
       }
    }
}
