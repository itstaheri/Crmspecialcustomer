using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Common
{
    public class CalculateTax1401 : CalculateTax
    {
        public override double Calculate(double TotalPrice)
        {
            return TotalPrice + ((TotalPrice*9)/100);
        }
    }
}
