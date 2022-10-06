using E_vent.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.Business.ValidationRules.FluentValidation
{
    public class EventTicketValidator : AbstractValidator<EventTicket>
    {
        public EventTicketValidator()
        {
            RuleFor(e => e.Quato).NotEmpty();
        }
    }
}
