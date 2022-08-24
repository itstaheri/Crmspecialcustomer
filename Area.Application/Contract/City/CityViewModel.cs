using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.City
{
    public class CityViewModel
    {
        public long CityId { get; set; }
        public string CityName { get; set; }
        public string CreationDate { get; set; }
        public long StateId { get; set; }
        public string StateName { get; set; }
    }
}
