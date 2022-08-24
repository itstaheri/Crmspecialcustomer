using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.Center
{
    public class CenterViewModel
    {
        public long CenterId { get; set; }
        public string CenterName { get; set; }
        public string Lenght { get; set; }
        public string Weight { get; set; }
        public long CityId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CreationDate { get; set; }
    }
}
