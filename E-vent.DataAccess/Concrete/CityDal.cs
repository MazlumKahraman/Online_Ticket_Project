﻿using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;

namespace E_vent.DataAccess.Concrete
{
    public class CityDal : EntityRepositoryBase<City, EventOnlineTicketContext>, ICityDal
    {
    }
}
