namespace E_vent.WebUI.Helpers.Extensions
{
    public static class CookieExtension
    {
        public static IServiceCollection AddAuthenticationCookies(this IServiceCollection services)
        {
            services.AddAuthentication(opt => opt.DefaultScheme = "admin_auth")
                .AddCookie("admin_auth", opt =>
                {
                    opt.LoginPath = "/Login";
                    opt.Cookie.Name = "admin_cookie";
                    opt.AccessDeniedPath = "/Login";
                    opt.LogoutPath = "/Login";
                });
            services.AddAuthentication(opt => opt.DefaultScheme = "user_auth")
                 .AddCookie("user_auth", opt =>
                 {
                     opt.LoginPath = "/Login";
                     opt.Cookie.Name = "user_cookie";
                     opt.AccessDeniedPath = "/Login";
                     opt.LogoutPath = "/Login";
                 });
            services.AddAuthentication(opt => opt.DefaultScheme = "entegrator_auth")
                 .AddCookie("entegrator_auth", opt =>
                 {
                     opt.LoginPath = "/Login";
                     opt.Cookie.Name = "entegrator_cookie";
                     opt.AccessDeniedPath = "/Login";
                     opt.LogoutPath = "/Login";
                 });
            return services;
        }
    }
}
