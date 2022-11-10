using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract
{
    public class OrderViewModel
    {
        public long RequestId { get;  set; }
        public long OrderId { get;  set; }
        public string CompanyName { get;  set; }
        public double TotalPrice { get;  set; } //قیمت کل
        public double TotalPriceAfterTax { get;  set; } //قیمت کل بعد از ارزش افزوده
        public bool IsPaidInFull { get;  set; } //وضعیت پرداخت کامل
        public string Code { get;  set; } //کدپیگیری
        public double UnpaidAmount { get;  set; } //مبلغ پرداخت نشده
        public DateTime CreationDate { get;  set; } //تاریخ ایجاد
    }
}
