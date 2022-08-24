using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.Center
{
    public class CreateCenterViewModel
    {
        public string CenterName { get; set; }
        public string Lenght { get; set; }
        public string Weight { get; set; }
        public long CityId { get; set; }
    }
}
