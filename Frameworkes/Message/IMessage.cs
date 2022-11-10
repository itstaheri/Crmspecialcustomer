using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes.Message
{
    public interface IMessage<Model>
    {
        Task SendMassege(Model model);
    }
}
