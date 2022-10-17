using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace E_vent.WebUI.Helpers
{
    public class AuthenticationHelper
    {
        public void SignIn(bool rememberMe, List<Claim> claims, HttpContext context, string session)
        {
            ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties() { IsPersistent = true };
            if (rememberMe == true)
                properties.ExpiresUtc = DateTime.UtcNow.AddDays(15);
            else
                properties.ExpiresUtc = DateTime.UtcNow.AddHours(1);
            context.SignInAsync(session,new ClaimsPrincipal(identity),properties);
        }

        public void SignOut(HttpContext context, string session)
        {
            context.SignOutAsync(session);
        }
    }
}
