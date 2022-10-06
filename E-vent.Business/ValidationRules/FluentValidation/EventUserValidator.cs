using E_vent.Entities.Concrete;
using FluentValidation;

namespace E_vent.Business.ValidationRules.FluentValidation
{
    public class EventUserValidator : AbstractValidator<EventUser>
    {
        public EventUserValidator()
        {
            RuleFor(e => e.ActionTime).NotEmpty();
        }
    }
}
