using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Languages.Data
{
    class IsYorN : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return $"{name}'s value wasn't Y or N.";
        }

        public override bool IsValid(object value)
        {
            return (string)value == "Y" || (string)value == "N";
        }
    }
}
