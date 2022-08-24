using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.State
{
    public class EditStateViewModel : CreateStateViewModel
    {
        public long StateId { get; set; }
    }
}
