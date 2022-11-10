using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderSupport
{
    public class EditOrderSupportViewModel : CreateOrderSupportViewModel
    {
        public long OrderSupportId { get; set; }
    }
}
