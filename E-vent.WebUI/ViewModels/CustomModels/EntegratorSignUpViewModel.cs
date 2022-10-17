using E_vent.WebUI.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace E_vent.WebUI.ViewModels.CustomModels
{
	public class EntegratorSignUpViewModel
    {
        [Required(ErrorMessage = "E-mail is required.")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "New password is required.")]
        [MinLength(8, ErrorMessage = "The password cant be less than 8 character")]
        [PasswordCheck(ErrorMessage = "The password must contains atleast one digit and one string character")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Entegrator name is required.")]
        public string EntegratorName { get; set; }
        [Required(ErrorMessage = "Domain name is required.")]
        public string DomainName { get; set; }

    }
}
