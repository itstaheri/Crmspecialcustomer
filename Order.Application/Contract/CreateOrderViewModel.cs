using Order.Application.Common;
using Order.Application.Contract.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract
{
    public class CreateOrderViewModel
    {
        public long RequestId { get;  set; }
        public double TotalPrice { get;  set; } //قیمت کل
        public double TotalPriceAfterTax { get;  set; } //قیمت کل بعد از ارزش افزوده
        public CreateOrderDetailViewModel orderDetail { get; set; }
    }
}
