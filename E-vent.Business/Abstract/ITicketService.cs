using E_vent.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.Business.Abstract
{
    public interface ITicketService
    {
        List<Ticket> GetAll(Expression<Func<Ticket, bool>> filter = null);
        Ticket Get(Expression<Func<Ticket, bool>> filter);
        void Add(Ticket ticket);    

    }
}
