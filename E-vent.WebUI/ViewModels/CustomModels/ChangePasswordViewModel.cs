using E_vent.WebUI.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace E_vent.WebUI.ViewModels.CustomModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage ="Current password is required.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        [MinLength(8,ErrorMessage ="The password cant be less than 8 character")]
        [PasswordCheck(ErrorMessage ="The password must contains atleast one digit and one string character")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword",ErrorMessage ="Confirm password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
