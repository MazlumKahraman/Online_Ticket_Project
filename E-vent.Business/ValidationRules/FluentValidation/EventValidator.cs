using E_vent.Entities.Concrete;
using FluentValidation;

namespace E_vent.Business.ValidationRules.FluentValidation
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Adress).NotEmpty();
            RuleFor(e => e.WithTicket).NotEmpty();
            RuleFor(e => e.BegginigTime).NotEmpty();
            RuleFor(e => e.CategoryId).NotEmpty();
            RuleFor(e => e.LastAttendance).NotEmpty();
            RuleFor(e => e.CityId).NotEmpty();
            RuleFor(e => e.UserId).NotEmpty();
            RuleFor(e => e.Quato).GreaterThanOrEqualTo(0);
            RuleFor(e => e.IsActive).NotEmpty();
        }
    }
}
