using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Application.Contract.Material
{
    public class CreateMaterialViewModel
    {
        public string Description { get; set; }
        public string MaterialPrice { get; set; }
        public string SalaryPrice { get; set; }
        public string UnitOfMaterial { get; set; }
        public string ServiceName { get; set; }
        public string UnitPrice { get; set; }
    }
}
