using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Application.Contract.Material
{
    public class EditMaterialViewModel : CreateMaterialViewModel
    {
        public long MaterialId { get; set; }
    }
}
