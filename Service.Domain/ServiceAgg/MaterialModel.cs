using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Domain.ServiceAgg
{
    public class MaterialModel : BaseEntity
    {
        public MaterialModel(string description, double materialPrice, double salaryPrice, string unit,string serviceName, long creatorId) : base(creatorId)
        {
            Description = description;
            MaterialPrice = materialPrice;
            SalaryPrice = salaryPrice;
            Unit = unit;
            ServiceName = serviceName;
        }
        public void Edit(string description, double materialPrice, double salaryPrice, string unit,string serviceName, long creatorId)
        {
            Description = description;
            MaterialPrice = materialPrice;
            SalaryPrice = salaryPrice;
            Unit = unit;
            CreatorId = creatorId;
            ServiceName = serviceName;
        }

        public string Description { get; private set; }
        public double MaterialPrice { get; private set; }
        public double SalaryPrice { get; private set; }
        public string Unit { get; private set; }
        public string ServiceName { get; private set; }


    }
}
