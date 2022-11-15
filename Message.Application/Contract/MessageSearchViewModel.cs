using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Contract
{
    public class MessageSearchViewModel
    {
        public string ?Index { get; set; }
        public int PageId { get; set; }
        public bool? IsRead { get; set; }
        public bool? MonthAgo { get; set; }
        public bool? WeekAgo { get; set; }
        public bool? DayAgo { get; set; }
        public bool? ToDay { get; set; }

    }
}
