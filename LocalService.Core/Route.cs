using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core
{
   public class Route
    {
       Dictionary<string, object> _dic = new Dictionary<string, object>();
       public Route() {
          
       }      
       /// <summary>
       /// {controller}/{action}/{id}
       /// </summary>
       public string Template { get; set; }

       /// <summary>
       /// 默认路由
       /// </summary>
       public object Defaults { get; set; }

       public Dictionary<string, object> DefaultAsDic()
       {
           if (Defaults == null) {
               throw new Exception("default route is not tempty");
           }

           if (_dic.Keys.Count > 0) {
               return _dic;
           }

           var type=this.Defaults.GetType();
           var propertyInfos = type.GetProperties();
           foreach (var property in propertyInfos)
           {
               if (!_dic.ContainsKey(property.Name)) {
                   _dic.Add(property.Name, property.GetValue(this.Defaults));
               }
           }

           return _dic;
       }
    }
}
