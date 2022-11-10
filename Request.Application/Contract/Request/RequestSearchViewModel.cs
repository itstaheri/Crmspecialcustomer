using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Request
{
    public class RequestSearchViewModel
    {
        public string CompanyName { get; set; }
        public string CityName { get; set; }
        public long CustomerCode { get; set; }
        public string ConstantPhone { get; set; }
        public string Phone { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsConfirm { get; set; } 
        public int pageId { get; set; }
        public bool Status { get; set; } = false;
    }
}
