using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WL_OA.Data.utils.tools
{
    public static class DataValidatorEx
    {        
        public static string IsInstanceValid(this object obj,bool isUseException = true)
        {
            var validContext = new ValidationContext(obj);
            var validResult = new List<ValidationResult>();
            var bIsValid = Validator.TryValidateObject(obj, validContext, validResult, true);

            if (!bIsValid)
            {
                if(isUseException) throw new Exception(validResult[0].ErrorMessage);
                return validResult[0].ErrorMessage;
            }
            return "";
        }
    }
}
