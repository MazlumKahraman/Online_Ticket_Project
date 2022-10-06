using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.DataAccess.Concrete
{
    public class EventTicketDal : EntityRepositoryBase<EventTicket, EventOnlineTicketContext>, IEventTicketDal
    {
    }
}
