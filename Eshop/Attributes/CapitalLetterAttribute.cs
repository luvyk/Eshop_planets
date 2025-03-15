using System.ComponentModel.DataAnnotations;

namespace WebMVC.Attributes
{
    public class CapitalLetterAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string? valueString = value as string;
            return valueString != null
                && valueString.Length > 0
                && char.IsUpper(valueString[0]);
        }
    }
}
