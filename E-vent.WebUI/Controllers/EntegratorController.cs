using E_vent.WebUI.Helpers;
using E_vent.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.WebUI.Controllers
{
	[Authorize(AuthenticationSchemes ="entegrator_auth")]
	public class EntegratorController : Controller
	{
		private readonly AuthenticationHelper _authenticationHelper;
		private static EntegratorViewModel entegrator;
		private readonly ApiHelper _apiHelper;
        public EntegratorController(AuthenticationHelper authenticationHelper, ApiHelper apiHelper)
		{
			_authenticationHelper = authenticationHelper;
			_apiHelper = apiHelper;
		}
        private void GetCurrentEntegrator()
        {
            string entegratorId = HttpContext.User.Claims.FirstOrDefault(u => u.Type.Equals("Id")).Value;
            var api = _apiHelper.Get<EntegratorViewModel>($"entegrator/get/{entegratorId}");
            entegrator = api.Result.Entity;

        }
        public IActionResult Index()
		{
			GetCurrentEntegrator();

            return View(entegrator);
		}
	}
}
