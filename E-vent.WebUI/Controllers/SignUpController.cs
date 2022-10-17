using E_vent.WebUI.Helpers;
using E_vent.WebUI.ViewModels;
using E_vent.WebUI.ViewModels.CustomModels;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.WebUI.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ApiHelper _apiHelper;
        public SignUpController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserSignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new UserViewModel
            {
                MailAdress=model.Email,
                Password=model.Password,
                IsActive=true,
                Detail=new UserDetailViewModel
                {
                    FirstName=model.FirstName,
                    MiddleName=model.MiddleName,
                    LastName=model.LastName
                }
            };
            var api = _apiHelper.Post("user/add", user);
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Entegrator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entegrator(EntegratorSignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var entegrator = new EntegratorViewModel
            {
                MailAdress = model.Email,
                Password = model.Password,
                IsActive = true,
                DomainName=model.DomainName,
                Name=model.EntegratorName,
                SecretKey= Guid.NewGuid().ToString()
            };
            var api = _apiHelper.Post("entegrator/add", entegrator);
            return RedirectToAction("Index", "Login");
        }
    }
}
