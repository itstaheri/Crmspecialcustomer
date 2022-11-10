using Frameworkes;
using Order.Domain.OrderSupportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAgg
{
    public class OrderDetailModel : BaseEntity
    {
        public OrderDetailModel(long orderId,long materialId, int coreCount, int coreCountSide,
            int value, int discountRate, double manualDiscount, double totalPrice, double payAmount, string description,long creatorId):base(creatorId)
        {
            OrderId = orderId;
            MaterialId = materialId;
            CoreCount = coreCount;
            CoreCountSide = coreCountSide;
            Value = value;
            DiscountRate = discountRate;
            ManualDiscount = manualDiscount;
            TotalPrice = totalPrice;
            PayAmount = payAmount;
            Description = description;
        }
        public void Edit(long materialId, int coreCount, int coreCountSide,
          int value, int discountRate, double manualDiscount, double totalPrice, double payAmount, string description, long creatorId) 
        {
            MaterialId = materialId;
            CoreCount = coreCount;
            CoreCountSide = coreCountSide;
            Value = value;
            DiscountRate = discountRate;
            ManualDiscount = manualDiscount;
            TotalPrice = totalPrice;
            PayAmount = payAmount;
            Description = description;
            CreatorId = creatorId;
        }

        //calculate discount and set finalPrice in PayAmount by Discountrate
        public void ApplyDiscountrate()
        {
            if(DiscountRate > 0)
            {
                PayAmount = TotalPrice - ((TotalPrice * DiscountRate) / 100);

            }
        }
        //calculate discount and set finalPrice in PayAmount by ManualDiscount
        public void ApplyManualDiscount()
        {
            if(ManualDiscount > 0)
            {
                PayAmount = TotalPrice - ManualDiscount;

            }
        }
        public void CalculationOfCustomerShare()
        {
            CustomerShare = TotalPrice/(CoreCount / CoreCountSide);
        }
        public long MaterialId { get; private set; }
        public long OrderId { get; private set; }
    
        public int CoreCount { get; private set; } //تعداد کور موجود
        public int CoreCountSide { get; private set; } //تعداد کور سهم طرف قرارداد
        public int Value { get; private set; } // مقدار
        public int DiscountRate { get; private set; } // درصد تخفیف
        public double ManualDiscount { get; private set; } // تخفیف دستی
        public double TotalPrice { get; private set; } //قیمت کل
        public double PayAmount { get; private set; } //قیمت نهایی پرداخت(بعد از تخفیف)ب
        public double CustomerShare { get; private set; } //سهم طرف قرار داد
        public string Description { get; private set; } //توضیحات
        public OrderModel Order { get; private set; }
       // public OrderSupportModel OrderSupport { get; private set; }
    }
}
