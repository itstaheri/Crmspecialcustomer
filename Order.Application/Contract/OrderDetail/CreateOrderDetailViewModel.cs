using Frameworkes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderDetail
{
    public class CreateOrderDetailViewModel
    {
        //[SelectValidation(0, ErrorMessage = "انتخاب جنس الزامی است")]
        public long MaterialId { get;  set; }
        public long OrderId { get;  set; }
        public int CoreCount { get;  set; } //تعداد کور موجود
        public int CoreCountSide { get;  set; } //تعداد کور سهم طرف قرارداد
        public int UnitPrice { get;  set; } //قیمت واحد فقط برای محاسبه!
        public int Value { get;  set; } // مقدار
        public int DiscountRate { get;  set; } // درصد تخفیف
        public double ManualDiscount { get;  set; } // تخفیف دستی
        public double TotalPrice { get;  set; } //قیمت کل
        public double PayAmount { get;  set; } //قیمت نهایی پرداخت(بعد از تخفیف)ب
        public string Description { get;  set; } //توضیحات
    }
}
