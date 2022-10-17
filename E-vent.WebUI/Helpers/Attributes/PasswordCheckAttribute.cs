using System.ComponentModel.DataAnnotations;

namespace E_vent.WebUI.Helpers.Attributes
{
    public class PasswordCheckAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
           return (value is null) 
                ? false 
                : value.ToString().Any(char.IsDigit) && value.ToString().Any(char.IsLetter);
        }

    }
}
