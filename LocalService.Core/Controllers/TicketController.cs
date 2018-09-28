using LocalService.Core.Models;
using LocalService.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
namespace LocalService.Core.Controllers
{
   public class TicketController:IController
    {

       public ResultModel handler(string data)
       {          
           try
           {
               var model = Newtonsoft.Json.JsonConvert.DeserializeObject<SaleOrderModel>(data);
               // 测试
               return ResultModel.Ok(ReplaceBill(model));

               // Print(model);
               //return ResultModel.Ok();
           }
           catch (Exception ex)
           {
               return ResultModel.Error(ex.Message);
           }          
          
       }

       private const string _BLLTemplate = "PosBillTemplate.txt";

       private void Print(SaleOrderModel model)
       {
           IPosPrinter _printService = new DriverPrinterService();
           var billTemplate = ReplaceBill(model);
           _printService.Print(billTemplate);          
       }

       private string ReplaceBill(SaleOrderModel model)
       {
           // var store = _db.Stores.FirstOrDefault(n => n.Id == model.StoreId);
           //打印模板
           string posTemplate = FileHelper.ReadText(_BLLTemplate);
           if (string.IsNullOrEmpty(posTemplate)) { throw new Exception("小票模板为空"); }
           posTemplate = posTemplate.ToLower();
           var lineLocation = posTemplate.LastIndexOf("##itemtemplate##");
           //分离商品item模板
           string billTemplate = posTemplate.ToLower().Substring(0, lineLocation);
           var itemStr = posTemplate.Substring(lineLocation);
           var len = itemStr.IndexOf("{");  //去掉　##itemtemplate##　以及换行符　从{{productname}}
           string itemTemplate = itemStr.Substring(len);
           //开始替换
           billTemplate = billTemplate.Replace("{{storename}}", "门店名");
           billTemplate = billTemplate.Replace("{{createdate}}", model.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"));
           billTemplate = billTemplate.Replace("{{ordercode}}", model.Code);
           billTemplate = billTemplate.Replace("{{createdby}}", model.CreatedBy.ToString());
           billTemplate = billTemplate.Replace("{{status}}", model.Status);
           //明细
           string productItems = "";
           foreach (var item in model.Items)
           {
               string tempItem = itemTemplate;
               tempItem = tempItem.Replace("{{productname}}", item.ProductName);
               tempItem = tempItem.Replace("{{productcode}}", item.ProductCode);
               tempItem = tempItem.Replace("{{price}}", item.RealPrice.ToString("F2"));
               tempItem = tempItem.Replace("{{quantity}}", item.Quantity.ToString());
               decimal amount = item.RealPrice * item.Quantity;
               tempItem = tempItem.Replace("{{amount}}", amount.ToString("F2"));
               productItems += tempItem; ;
           }
           billTemplate = billTemplate.Replace("{{items}}", productItems);
           //应收应付
           billTemplate = billTemplate.Replace("{{orderamount}}", model.OrderAmount.ToString("F2"));
           billTemplate = billTemplate.Replace("{{quantitytotal}}", model.GetQuantityTotal().ToString());
           billTemplate = billTemplate.Replace("{{discountamount}}", model.GetTotalDiscountAmount().ToString("F2"));
           billTemplate = billTemplate.Replace("{{payamount}}", model.PayAmount.ToString("F2"));
           billTemplate = billTemplate.Replace("{{chargeamount}}", model.GetChargeAmount().ToString("F2"));
           billTemplate = billTemplate.Replace("{{paymentway}}", model.PaymentWay);
           billTemplate = billTemplate.Replace("{{onlinepayamount}}", model.OnlinePayAmount.ToString("F2"));
           return billTemplate;
       }

       
    }
}
