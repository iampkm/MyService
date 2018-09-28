using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Core.Models
{
   public class SaleOrderModel
    {
       public SaleOrderModel()
        {
            this.Items = new List<SaleOrderItemModel>();
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
            this.Status = "create";
            this.OrderType = 1;
            this.OrderLevel = "normal";
            this.PaymentWay = "cash";
        }
        public string Code { get; set; }

        public int StoreId { get; set; }
        /// <summary>
        /// Pos 机ID
        /// </summary>
        public int PosId { get; set; }
        /// <summary>
        /// 订单类型：销售单1，销售退单2
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentWay { get; set; }
        /// <summary>
        /// 退款账户
        /// </summary>
        public string RefundAccount { get; set; }
        /// <summary>
        /// 支付日期
        /// </summary>
        public DateTime? PaidDate { get; set; }
        /// <summary>
        /// 订单金额 = 实际价格RealAmount * 数量
        /// </summary>
        public decimal OrderAmount { get; private set; }
        /// <summary>
        /// 现金支付金额
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 刷卡支付，微信支付，阿里支付等在线支付金额
        /// </summary>
        public decimal OnlinePayAmount { get; set; }

        /// <summary>
        /// 销售单状态
        /// </summary>
        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        /// <summary>
        /// 班次代码
        /// </summary>
        public string WorkScheduleCode { get; set; }

        public int IsSync { get; set; }
        /// <summary>
        /// 订单级别： 0 普通订单，1 Vip订单
        /// </summary>
        public string OrderLevel { get; set; }

        public virtual List<SaleOrderItemModel> Items { get; set; }

        public decimal GetChargeAmount()
        {
            return this.PayAmount + this.OnlinePayAmount - this.OrderAmount;
        }
        /// <summary>
        /// 总优惠金额
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalDiscountAmount()
        {
            return this.Items.Sum(n => n.SalePrice - n.RealPrice);
        }

        public int GetQuantityTotal()
        {
            return this.Items.Sum(n => n.Quantity);
        }
    }
}
