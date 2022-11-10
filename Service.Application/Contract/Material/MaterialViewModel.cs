using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Application.Contract.Material
{
    public class MaterialViewModel
    {
        public long MaterialId { get; set; }
        public string Description { get;  set; }
        public double MaterialPrice { get;  set; }
        public double SalaryPrice { get;  set; }
        public string UnitOfMaterial { get;  set; }
        public double UnitPrice { get;  set; }
        public string ServiceName { get; set; }
        public string CreationDateString { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
