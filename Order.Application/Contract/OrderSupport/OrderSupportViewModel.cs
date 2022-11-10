using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderSupport
{
    public class OrderSupportViewModel
    {
        public long OrderSupportId { get; set; }
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }

        public double SupportPrice { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
        public double MaterialPrice { get; set; }
        public string ServiceName { get; set; }
    }
}
