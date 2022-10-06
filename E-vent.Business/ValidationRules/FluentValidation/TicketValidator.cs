using E_vent.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.Business.ValidationRules.FluentValidation
{
    public class TicketValidator:AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t=>t.ActionTime).NotEmpty();
            RuleFor(t => t.EventTicketId).NotEmpty();
            RuleFor(t => t.UserId).NotEmpty();
            RuleFor(t => t.IsActive).NotEmpty();
        }
    }
}
