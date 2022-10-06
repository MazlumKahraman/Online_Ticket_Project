using E_vent.Entities.Concrete;
using FluentValidation;

namespace E_vent.Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
