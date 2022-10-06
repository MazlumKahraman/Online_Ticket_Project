using E_vent.Entities.Concrete;
using FluentValidation;

namespace E_vent.Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.MailAdress).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.IsActive).NotEmpty();
        }
    }
}
