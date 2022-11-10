using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderDetail
{
    public class EditOrderDetailViewModel : CreateOrderDetailViewModel
    {
        public long OrderDetailId { get; set; }
    }
}
