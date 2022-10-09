using System.ComponentModel.DataAnnotations;

namespace Assignment.CustomValidation
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object date, ValidationContext validationContext)
        {
            if ((Convert.ToDateTime(date) <= Convert.ToDateTime("12/31/9999")
                &&
                (Convert.ToDateTime(date) >= Convert.ToDateTime("1/1/1900"))))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Start date must be after 1/1/1990");
            }
        }
    }
}