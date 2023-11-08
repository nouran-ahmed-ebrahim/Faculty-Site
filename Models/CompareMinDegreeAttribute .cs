using System.ComponentModel.DataAnnotations;

namespace Asp.net.Models
{
    public class CompareMinDegreeAttribute : ValidationAttribute
    {
        public string msg { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                int minDegree = (int)value;
                int Degree = ((Course)validationContext.ObjectInstance).Degree;
                if (minDegree > Degree)
                {
                    return new ValidationResult("Min Digree must be less than or equal Degree");
                }
                return ValidationResult.Success;
            }
        }
    }
}
