using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.State
{
    public class StateViewModel
    {
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string CreationDate { get; set; }
    }
}
