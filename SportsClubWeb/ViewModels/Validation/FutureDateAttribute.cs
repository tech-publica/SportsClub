using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.ViewModels.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "You can only reserve from the next hour on";
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
        
            var dateValue = objValue as DateTime? ?? new DateTime();       
          
            if (dateValue <= DateTime.Now)
            {
                return new ValidationResult(ChooseErrorMessage());
                //return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        private string ChooseErrorMessage()
        {
            if(!string.IsNullOrEmpty(this.ErrorMessage))
            {
                return this.ErrorMessage;
            }
            return "The date must be in the future";
        }
    }
}
