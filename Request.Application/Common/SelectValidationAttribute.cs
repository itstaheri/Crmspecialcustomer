using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Common
{
    public class SelectValidationAttribute : ValidationAttribute
    {
        // Internal field to hold the id value.
        private long _Id;

        public SelectValidationAttribute(long id)
        {
            _Id = id;
        }
        public override bool IsValid(object value)
        {
            var Id = (long)value;
            if(Id == 0)
            {
                return false;
            
            }
            return true;
        }
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}
