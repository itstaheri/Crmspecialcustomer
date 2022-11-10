using Frameworkes;
using Order.Domain.OrderDocumentReceiptAgg;
using Order.Domain.OrderSupportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAgg
{
    public class OrderModel : BaseEntity
    {
        public OrderModel(long requestId, double totalPrice, string code, long creatorId) : base(creatorId)
        {
            RequestId = requestId;
            TotalPrice = totalPrice;
            Code = code;
            IsPaidInFull = false;
            DocumentReceipt = new();
            OrderDetails = new();
        }
        public void Edit(double totalPrice, long creatorId)
        {
            TotalPrice = totalPrice;
            CreatorId = creatorId;
        }


        //make true the IsPaidInFull
        public void PaidInFull() => IsPaidInFull = true;
        //make false the IsPaidInFull
        public void UnPaidInFull() => IsPaidInFull = false;


        //set TotalPrice AfterTax
        public void AfterTax(double totalPriceAfterTax)
        {
            TotalPriceAfterTax = totalPriceAfterTax;
        }
        //add orderDetails
        public void AddDetail(OrderDetailModel orderDetail)
        {
            OrderDetails.Add(orderDetail);
        }

        public long RequestId { get; private set; }
        public double TotalPrice { get; private set; } //قیمت کل
        public double TotalPriceAfterTax { get; private set; } //قیمت کل بعد از ارزش افزوده
        public bool IsPaidInFull { get; private set; } //وضعیت پرداخت کامل
        public string Code { get; private set; }
        public List<OrderDocumentReceiptModel> DocumentReceipt { get; private set; }
        public List<OrderDetailModel> OrderDetails { get; private set; }
    }
}
