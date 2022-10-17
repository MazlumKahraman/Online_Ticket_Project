using E_vent.WebUI.Helpers;
using E_vent.WebUI.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(a => new ApiHelper(builder.Configuration.GetSection("x-api-key").Value));
builder.Services.AddScoped<AuthenticationHelper>();
builder.Services.AddAuthenticationCookies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
