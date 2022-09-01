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
        public MaterialModel(string description, double materialPrice, double salaryPrice, string unitOfMaterial, string serviceName, double unitPrice, long creatorId) : base(creatorId)
        {
            Description = description;
            MaterialPrice = materialPrice;
            SalaryPrice = salaryPrice;
            UnitOfMaterial = unitOfMaterial;
            ServiceName = serviceName;
            UnitPrice = unitPrice;
        }
        public void Edit(string description, double materialPrice, double salaryPrice, string unitOfMaterial, string serviceName, double unitPrice, long creatorId)
        {
            Description = description;
            MaterialPrice = materialPrice;
            SalaryPrice = salaryPrice;
            UnitPrice = unitPrice;
            CreatorId = creatorId;
            ServiceName = serviceName;
            UnitPrice = unitPrice;
            UnitOfMaterial = unitOfMaterial;
        }

        public string Description { get; private set; }
        public double MaterialPrice { get; private set; }
        public double SalaryPrice { get; private set; }
        public string UnitOfMaterial { get; private set; }
        public string ServiceName { get; private set; }
        public double UnitPrice { get; private set; }

    }
}
