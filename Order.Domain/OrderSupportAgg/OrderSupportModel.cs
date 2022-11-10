using Frameworkes;
using Order.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderSupportAgg
{
    public class OrderSupportModel : BaseEntity
    {
        public OrderSupportModel(long orderId, long orderDetailId, double supportPrice, int discountRate, double manualDiscount,long creatorId) : base(creatorId)
        {
            OrderId = orderId;
            OrderDetailId = orderDetailId;
            SupportPrice = supportPrice;
            DiscountRate = discountRate;
            ManualDiscount = manualDiscount;
        }

        public void Edit(double supportPrice,int discountRate,double manualDiscount,long creatorId)
        {
            SupportPrice = supportPrice;
            DiscountRate =discountRate;
            ManualDiscount =manualDiscount;
            CreatorId = creatorId;
        }
        //calculate discount and set finalPrice in PayAmount by Discountrate
        public void ApplyDiscountrate()
        {
            if(DiscountRate > 0)
            {
                PayAmount = SupportPrice - ((SupportPrice * DiscountRate) / 100);

            }

        }
        //calculate discount and set finalPrice in PayAmount by ManualDiscount
        public void ApplyManualDiscount()
        {
            if(ManualDiscount > 0)
            {
                PayAmount = SupportPrice - ManualDiscount;

            }
        }
        public long OrderId { get; private set; }
        public long OrderDetailId { get; private set; }
        public double SupportPrice { get; private set; }
        public int DiscountRate { get; private set; }
        public double ManualDiscount { get; private set; }
        public double PayAmount { get; private set; }
        //public OrderDetailModel OrderDetail { get;private set; }
    }
}
