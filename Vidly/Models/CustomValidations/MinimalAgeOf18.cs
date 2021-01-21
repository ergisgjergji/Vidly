using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.CustomValidations
{
    public class MinimalAgeOf18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
                return new ValidationResult("Birthdate is required");

            var birthdate = DateTime.Parse(value.ToString());
            var now = DateTime.Now;

            var age = now.Year - birthdate.Year;

            if (birthdate.Month > now.Month)
                age--;
            else
            {
                if (birthdate.Month == now.Month)
                    if (birthdate.Day > now.Day)
                        age--;
            }

            if (age < 18)
                return new ValidationResult("Customer should be at least 18 years old");

            return ValidationResult.Success;
        }
    }
}