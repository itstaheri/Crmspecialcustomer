using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract
{
    public class SearchOrderViewModel
    {
        public string ?Code { get; set; }
        public bool IsPaidFull { get; set; }
        public string ?FromDate { get; set; }
        public string ?ToDate { get; set; }
        public string ?CompanyName { get; set; }
        public bool Status  { get; set; } = false;
        public int PageId { get; set; } = 1; //pagination
    }
}
