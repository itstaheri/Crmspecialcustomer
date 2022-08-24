using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes
{
    public class BaseEntity
    {
        public BaseEntity(long creatorId)
        {
            CreationDate = DateTime.Now;
            CreatorId = creatorId;
        }
        public long Id { get;private set; }
        public long CreatorId { get;protected set; } //Id of the last registrant or editor
        public DateTime CreationDate { get;private set; }
    }
}
