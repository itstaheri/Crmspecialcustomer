using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
        public long Id { get;private set; }
        public DateTime CreationDate { get;private set; }
    }
}
