using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Abstract;
using E_vent.DataAccess.Concrete;

namespace E_vent.API.Helpers.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICityDal, CityDal>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<IEntegratorDal, EntegratorDal>();
            services.AddScoped<IEntegratorService, EntegratorManager>();
            services.AddScoped<IEventDal, EventDal>();
            services.AddScoped<IEventService, EventManager>();
            services.AddScoped<IEventTicketDal, EventTicketDal>();
            services.AddScoped<IEventTicketService, EventTicketManager>();
            services.AddScoped<IEventUserDal, EventUserDal>();
            services.AddScoped<IEventUserService, EventUserManager>();
            services.AddScoped<ITicketDal, TicketDal>();
            services.AddScoped<ITicketService, TicketManager>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IUserService, UserManager>();
        }
    }
}
