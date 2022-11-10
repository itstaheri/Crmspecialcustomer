using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Common
{
    public abstract class CalculateTax
    {
        public abstract double Calculate(double TotalPrice);
       
       
    }
}
