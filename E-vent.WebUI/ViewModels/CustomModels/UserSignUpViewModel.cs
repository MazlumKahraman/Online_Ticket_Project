using E_vent.WebUI.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace E_vent.WebUI.ViewModels.CustomModels
{
	public class UserSignUpViewModel
	{
        [Required(ErrorMessage ="E-mail is required.")]
        [EmailAddress(ErrorMessage ="Invalid e-mail address.")]
		public string Email { get; set; }
        [Required(ErrorMessage = "New password is required.")]
        [MinLength(8, ErrorMessage = "The password cant be less than 8 character")]
        [PasswordCheck(ErrorMessage = "The password must contains atleast one digit and one string character")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="First name is required.")]
		public string FirstName { get; set; }
		public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
	}
}
