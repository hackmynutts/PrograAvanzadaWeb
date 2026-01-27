using System.ComponentModel.DataAnnotations;

namespace ProgramacionAvanzadaWeb.Validations
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime dateTime)
            {
                return new ValidationResult("El valor no es una fecha valida.");
            }
            if (dateTime < DateTime.UtcNow.Date)
            {
                return new ValidationResult("La fecha debe de ser mayor a la fecha y hora actual.");
            }
            return ValidationResult.Success;
        }
    }
}
