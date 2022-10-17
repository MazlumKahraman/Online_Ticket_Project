
using E_vent.WebUI.Helpers;
using E_vent.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.WebUI.Controllers
{
    [Authorize(AuthenticationSchemes ="admin_auth")]
    public class AdminController : Controller
    {
        private ApiHelper _apiHelper;
        private AuthenticationHelper _authenticationHelper;
        public AdminController(ApiHelper apiHelper, AuthenticationHelper authenticationHelper)
        {
            _apiHelper = apiHelper;
            _authenticationHelper = authenticationHelper;
        }
        public IActionResult Index()
        {
            var api = _apiHelper.Get<List<EventViewModel>>("event/getall?navigate=1");
            var model = api.Result.Entity;
            model = model.OrderByDescending(m => m.Id).Take(5).ToList();
            return View(model);
        }

        public IActionResult Logout()
        {
            _authenticationHelper.SignOut(HttpContext, "admin_auth");
            return RedirectToAction("Index", "Login");
        }
        #region Category
        [HttpGet]
        public IActionResult Categories()
        {
            var api = _apiHelper.Get<List<CategoryViewModel>>("category/getall?navigate=1");
            var model = api.Result.Entity;
            return View(model);
        }


    
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel category)
        {
            var api = _apiHelper.Post("category/add", category);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int categoryId)
        {
            var api = _apiHelper.Get<CategoryViewModel>($"category/get/{categoryId}");
            var model = api.Result.Entity;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryViewModel category)
        {
            var api = _apiHelper.Put("category/update",category);
            TempData["success"] = api.Result.Success;  //refresh olayı
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int categoryId)
        {
            var api = _apiHelper.Patch<CategoryViewModel>($"category/delete/{categoryId}", null);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Categories", "Admin");
        }

        #endregion

        #region City
        [HttpGet]
        public IActionResult Cities()
        {
            var api = _apiHelper.Get<List<CityViewModel>>("city/getall?navigate=1");
            var model = api.Result.Entity;
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCity(int cityId)
        {
            var api = _apiHelper.Get<CityViewModel>($"city/get/{cityId}");
            var model = api.Result.Entity;
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCity(CityViewModel city)
        {
            var api = _apiHelper.Post("city/add", city);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Cities", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateCity(int cityId)
        {
            var api = _apiHelper.Get<CityViewModel>($"city/get/{cityId}");
            var model = api.Result.Entity;
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateCity(CityViewModel city)
        {
            var api = _apiHelper.Put("city/update", city);
            TempData["success"] = api.Result.Success;  //refresh olayı
            return RedirectToAction("Cities", "Admin");
        }


        [HttpGet]
        public IActionResult DeleteCity(int cityId)
        {
            var api = _apiHelper.Patch<CityViewModel>($"city/delete/{cityId}", null);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Cities", "Admin");
        }
        #endregion

        #region Event
        [HttpGet]
        public IActionResult Events()
        {
            var api = _apiHelper.Get<List<EventViewModel>>("event/getall?navigate=1");
            var model = api.Result.Entity;
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateEvent(int eventId)
        {
            var api = _apiHelper.Get<EventViewModel>($"event/get/{eventId}?navigate=1");
            var model = api.Result.Entity;
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateEvent(EventViewModel @event)
        {
            var api = _apiHelper.Put("event/update", @event);
            TempData["success"] = api.Result.Success;  //refresh olayı
            return RedirectToAction("Events", "Admin");
        }


        [HttpGet]
        public IActionResult DeleteEvent(int eventId)
        {
            var api = _apiHelper.Put<EventViewModel>($"event/delete/{eventId}",null);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Events", "Admin");
        }

        [HttpGet]
        public IActionResult ApproveEvent(int eventId)
        {
            var api = _apiHelper.Patch<EventViewModel>($"event/approve/{eventId}", null);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Events", "Admin");
        }

        [HttpGet]
        public IActionResult DeclineEvent(int eventId)
        {
            var api = _apiHelper.Patch<EventViewModel>($"event/decline/{eventId}", null);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Events", "Admin");
        }
        #endregion

        #region User
        [HttpGet]
        public IActionResult Users()
        {
            var api = _apiHelper.Get<List<UserViewModel>>("user/getall?navigate=1");
            var model = api.Result.Entity;
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateUser(int userId)
        {
            var api = _apiHelper.Get<UserViewModel>($"user/get/{userId}?navigate=1");
            var model = api.Result.Entity;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserViewModel user)
        {
            var api = _apiHelper.Put("user/update", user);
            TempData["success"] = api.Result.Success;  //refresh olayı
            return RedirectToAction("Users", "Admin");
        }


        [HttpPost]
        public IActionResult DeleteUser(UserViewModel user)
        {
            var api = _apiHelper.Patch($"user/delete", user);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Users", "Admin");
        }
        #endregion

    }
}
