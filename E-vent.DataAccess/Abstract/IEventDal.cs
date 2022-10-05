using E_vent.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.DataAccess.Abstract
{
    public interface IEventDal:IEntityRepository<Event>
    {
    }
}
