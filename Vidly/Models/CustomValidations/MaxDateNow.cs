using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.CustomValidations
{
    public class MaxDateNow : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            var date = DateTime.Parse(value.ToString());

            if (date <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date cannot be greater than today.");
            }
        }
    }
}