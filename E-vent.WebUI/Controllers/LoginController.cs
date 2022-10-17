using E_vent.WebUI.Helpers;
using E_vent.WebUI.ViewModels;
using E_vent.WebUI.ViewModels.CustomModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_vent.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private ApiHelper _apiHelper;
        private AuthenticationHelper _authenticationHelper;
        public LoginController(ApiHelper apiHelper, AuthenticationHelper authenticationHelper)
        {
            _apiHelper = apiHelper;
            _authenticationHelper = authenticationHelper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IRequestCookieCollection cookies = HttpContext.Request.Cookies;
            if (cookies.ContainsKey("user_cookie"))
                return RedirectToAction("Index", "User");
            else if (cookies.ContainsKey("entegratior_cookie"))
                return RedirectToAction("Index", "Entegrator");
            else if (cookies.ContainsKey("admin_cookie"))
                return RedirectToAction("Index", "Admin");
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (!model.IsEntegrator)
            {
                var api = _apiHelper.Get<UserViewModel>($"user/get/{model.UserName}/{model.Password}");
                if (api.Result.Entity is not null)
                {
                    var claims = new List<Claim>
                {
                    new Claim("Id",api.Result.Entity.Id.ToString()),
                    new Claim(ClaimTypes.Role,(api.Result.Entity.DetailId is null)?"admin":"user")
                };
                    if (api.Result.Entity.DetailId is null)
                    {
                        _authenticationHelper.SignIn(model.RememberMe, claims, HttpContext, "admin_auth");
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        _authenticationHelper.SignIn(model.RememberMe, claims, HttpContext, "user_auth");
                        return RedirectToAction("Index", "User");

                    }
                }
            }
            var entegratorApi = _apiHelper.Get<EntegratorViewModel>($"entegrator/get/{model.UserName}/{model.Password}");
            if(entegratorApi.Result.Entity is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Id",entegratorApi.Result.Entity.Id.ToString()),
                    new Claim(ClaimTypes.Role,"entegrator")
                };
                _authenticationHelper.SignIn(model.RememberMe, claims, HttpContext, "entegrator_auth");
                return RedirectToAction("Index", "Entegrator");
            }
            ViewBag.Error = "Incorrect mail adress or password!";
            return View();
        }
        public IActionResult PasswordReset()
        {
            return View();
        }
    }
}
