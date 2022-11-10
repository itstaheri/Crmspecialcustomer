using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderDetail
{
    public class OrderDetailViewModel
    {
        public long OrderDetailId { get; set; }
        //Material Detail
        public long MaterialId { get; set; }
        public double MaterialPrice { get; set; }
        public double SalaryPrice { get; set; }
        public string UnitOfMaterial { get; set; }
        public double UnitPrice { get; set; }
        public string ServiceName { get; set; }
        //
        public long OrderId { get; set; }
        public int CoreCount { get; set; } //تعداد کور موجود
        public int CoreCountSide { get; set; } //تعداد کور سهم طرف قرارداد
        public int Value { get; set; } // مقدار
        public int DiscountRate { get; set; } // درصد تخفیف
        public double ManualDiscount { get; set; } // تخفیف دستی
        public double TotalPrice { get; set; } //قیمت کل
        public double PayAmount { get; set; } //قیمت نهایی پرداخت(بعد از تخفیف)ب
        public double CustomerShare { get; set; } //سهم طرف قرار داد
        public string Description { get; set; } //توضیحات
        public string CreationDate { get; set; }
    }
}
