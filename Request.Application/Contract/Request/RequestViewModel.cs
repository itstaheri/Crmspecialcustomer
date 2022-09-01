using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Request
{
    public class RequestViewModel
    {
        public long RequestId { get; set; }
        public long StateId { get;  set; }
        public string StateName { get;  set; }
        public string CompanyName { get;  set; }
        public long CityId { get;  set; }
        public string CityName { get;  set; }
        public long CustomerCode { get;  set; }
        public string ApplicantName { get;  set; }
        public long ServiceId { get;  set; }
        public string ServiceName { get;  set; }
        public string Origin { get;  set; }
        public string Destination { get;  set; }
        public string ConstantPhone { get;  set; }
        public string Phone { get;  set; }
        public bool IsConfirm { get;  set; }
        public string CreationDate  { get; set; }
        public string LetterPhoto  { get; set; }
        public string LetterId  { get; set; }
    }
}
