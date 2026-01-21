using System.ComponentModel.DataAnnotations;

namespace ProgramacionAvanzadaWeb.Validations
{
    public class ValidatePrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not decimal decimalValue)
            {
                return new ValidationResult("El valor no es un número decimal válido.");
            }
            if (decimalValue < 0 || decimalValue > 500)
            {
                return new ValidationResult("El precio debe ser mayor que cero y menor a 500.");
            }
            return ValidationResult.Success;
        }
    }

}
