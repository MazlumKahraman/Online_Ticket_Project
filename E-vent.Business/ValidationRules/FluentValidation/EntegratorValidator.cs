using E_vent.Entities.Concrete;
using FluentValidation;

namespace E_vent.Business.ValidationRules.FluentValidation
{
    public class EntegratorValidator : AbstractValidator<Entegrator>
    {
        public EntegratorValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.MailAdress).EmailAddress().NotEmpty();
            RuleFor(e => e.DomainName).NotEmpty();
            RuleFor(e => e.Password).NotEmpty();
            RuleFor(e => e.SecretKey).NotEmpty();
        }
    }
}
