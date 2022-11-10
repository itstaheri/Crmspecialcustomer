using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderSupport
{
    public class CreateOrderSupportViewModel
    {
        public long OrderId { get; set; }
        public long OrderDetailId { get; set; }
        public double SupportPrice { get; set; }
        public int DiscountRate { get; set; }
        public double ManualDiscount { get; set; }
    }
}
