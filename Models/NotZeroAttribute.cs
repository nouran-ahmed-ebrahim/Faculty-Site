using System.ComponentModel.DataAnnotations;

namespace Asp.net.Models
{
    public class NotZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                int DepartmentId = (int)value;
                if (DepartmentId == 0)
                {
                    return new ValidationResult("Please choose Department");
                }
                return ValidationResult.Success;
            }
        }
    }
}
