using E_vent.WebUI.Helpers;
using E_vent.WebUI.ViewModels;
using E_vent.WebUI.ViewModels.CustomModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace E_vent.WebUI.Controllers
{
    [Authorize(AuthenticationSchemes = "user_auth")]

    public class UserController : Controller
    {
        private ApiHelper _apiHelper;
        private AuthenticationHelper _authenticationHelper;
        private static UserViewModel currentUser;
        public UserController(ApiHelper apiHelper, AuthenticationHelper authenticationHelper)
        {
            _apiHelper = apiHelper;
            _authenticationHelper = authenticationHelper;
        }
        private void GetCurrentUser()
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(u => u.Type.Equals("Id")).Value;
            var api = _apiHelper.Get<UserViewModel>($"user/get/{userId}?navigate=1");
            currentUser = api.Result.Entity;

        }
        public IActionResult Logout()
        {
            _authenticationHelper.SignOut(HttpContext, "user_auth");
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Index(int? cityId, int? categoryId)
        {
            //all events
            GetCurrentUser();
            var api = _apiHelper.Get<List<EventViewModel>>("event/getall?navigate=1");
            var model = api.Result.Entity.Where(e=>e.StatusId==2).ToList();
            var cityApi = _apiHelper.Get<List<CityViewModel>>("city/getall");
            var categoryApi = _apiHelper.Get<List<CategoryViewModel>>("category/getall");
            if (cityId is not null)
                model = model.Where(m => m.CityId == cityId).ToList();
            if (categoryId is not null)
                model = model.Where(m => m.CategoryId == categoryId).ToList();
            ViewBag.Categories = categoryApi.Result.Entity;
            ViewBag.Cities = cityApi.Result.Entity;
            return View(model);      
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Profile()
        {
            GetCurrentUser();
            ViewBag.Success = TempData["success"];
            return View(currentUser);
        }

        [HttpPost]
        public IActionResult Profile(UpdateProfileViewModel model)
        {

            var tempModel = new UserViewModel
            {
                Id=currentUser.Id,
                Detail= new UserDetailViewModel
                {
                    FirstName=model.FirstName,
                    MiddleName=model.MiddleName,
                    LastName=model.LastName
                }
            };
            var api = _apiHelper.Put("user/update", tempModel);
            return RedirectToAction("Index","User");
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            GetCurrentUser();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!currentUser.Password.Equals(model.CurrentPassword))
            {
                ModelState.AddModelError("", "Current password is wrong.");
                return View();
            }
            if (currentUser.Password.Equals(model.NewPassword))
            {
                ModelState.AddModelError("", "New password cant be same as current password");
                return View();
            }
            var api = _apiHelper.Patch($"user/changepassword/{currentUser.Id}/{model.NewPassword}", currentUser);
            TempData["success"] = api.Result.Success;
            return RedirectToAction("Profile", "User");
        }
        #region Events
        [HttpGet]
        public IActionResult MyEvents()
        {
            GetCurrentUser();
            var api = _apiHelper.Get<List<EventViewModel>>($"event/getall/{currentUser.Id}?navigate=1");
            var model = api.Result.Entity;
            return View(model);
        }


        [HttpGet]
        public IActionResult AddEvent()
        {
            GetCategoryAndCity();

            return View();
        }

        private void GetCategoryAndCity()
        {
            var categoryApi = _apiHelper.Get<List<CategoryViewModel>>("category/getall");
            var cityApi = _apiHelper.Get<List<CityViewModel>>("city/getall");
            var categories = categoryApi.Result.Entity;
            var cities = cityApi.Result.Entity;
            ViewBag.Cities = cities;
            ViewBag.Categories = categories;
        }

        [HttpPost]
        public IActionResult AddEvent(EventViewModel @event)
        {
            if (@event.BegginigTime< DateTime.Now || @event.LastAttendance < DateTime.Now)
            {
                ModelState.AddModelError("", "You cant add event to past time");
                GetCategoryAndCity();
                return View(@event);
            }
            @event.StatusId = 1;
            @event.IsActive = true;
            @event.UserId = currentUser.Id;
            @event.WithTicket = @event.Price > 0;
            var api = _apiHelper.Post("event/add", @event);
            TempData["addEventSuccess"] = api.Result.Success;
            return RedirectToAction("MyEvents", "User");
        }

        [HttpGet]
        public IActionResult EventDetail(int eventId)
        {
            var api = _apiHelper.Get<EventViewModel>($"event/get/{eventId}?navigate=1");
            if (api.Result.Entity is null)
                return RedirectToAction("Index", "User");
            ViewBag.Changeable = api.Result.Entity.UserId == currentUser.Id && (api.Result.Entity.LastAttendance - DateTime.Now).TotalDays > 5;
            var attendanceApi = _apiHelper.Get<EventUserViewModel>($"eventuser/get/{eventId}/{currentUser.Id}");
            ViewBag.IsAttend = !(attendanceApi.Result.Entity is null);

            if (api.Result.Entity.WithTicket)
            {
                var entegratorApi = _apiHelper.Get<List<EventTicketViewModel>>($"eventticket/getall/{eventId}");
                if(entegratorApi.Result.Entity is not null)
                {
                    var entegrators = entegratorApi.Result.Entity.Select(e => e.Entegrator).ToList();
                    ViewBag.Entegrators = entegrators;
                }
            }
            return View(api.Result.Entity);
        }
        [HttpPost]
        public IActionResult UpdateEvent(EventViewModel model)
        {
            var api = _apiHelper.Put("event/update", model);
            return RedirectToAction("MyEvents", "User");
        }
        [HttpGet]
        public IActionResult CancelEvent(int eventId)
        {
            var eventApi = _apiHelper.Get<EventViewModel>($"event/get/{eventId}");
            var model = eventApi.Result.Entity;
            if (model.UserId != currentUser.Id)
                return RedirectToAction("Index", "User");
            if ((model.LastAttendance - DateTime.Now).TotalDays < 5)
                return RedirectToAction("MyEvents", "User");
            var deleteApi = _apiHelper.Patch<EventViewModel>($"event/delete/{eventId}", model);
            return RedirectToAction("MyEvents", "User");
        }

        [HttpGet]
        public IActionResult JoinEvent(int eventId)
        {
            var api = _apiHelper.Get<EventUserViewModel>($"eventuser/get/{eventId}/{currentUser.Id}");
            if(api.Result.Entity is null)
            {
                var eventUser = new EventUserViewModel
                {
                    ActionTime = DateTime.Now,
                    EventId = eventId,
                    UserId = currentUser.Id
                };
                var attendanceApi = _apiHelper.Post("eventuser/add",eventUser);
                TempData["eventAttendanceSuccess"] = attendanceApi.Result.Success;
            }
            return RedirectToAction("EventDetail", "User", new { eventId = eventId });
        }
        [HttpGet]
        public IActionResult LeaveEvent(int eventId)
        {
            var api = _apiHelper.Get<EventUserViewModel>($"eventuser/get/{eventId}/{currentUser.Id}");
            if (api.Result.Entity is not null)
            {
                var model = api.Result.Entity;
                var attendanceApi = _apiHelper.Patch($"eventuser/update/{model.Id}", model);
                TempData["eventAttendanceSuccess"] = attendanceApi.Result.Success;
            }
            return RedirectToAction("EventDetail", "User", new { eventId = eventId });

        }

        public IActionResult JoinedEvents()
        {
            GetCurrentUser();
            var api = _apiHelper.Get<List<EventUserViewModel>>($"eventuser/GetJoined/{currentUser.Id}");
            return View(api.Result.Entity);
        }

        public IActionResult NextJoinEvents()
        {
            GetCurrentUser();
            var api = _apiHelper.Get<List<EventUserViewModel>>($"eventuser/GetNextJoins/{currentUser.Id}");
            return View(api.Result.Entity);
        }
        #endregion
    }
}
