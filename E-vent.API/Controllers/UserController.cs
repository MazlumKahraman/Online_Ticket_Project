using E_vent.API.Helpers.Attributes;
using E_vent.Business.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public List<User> GetAll(int? navigate)
        {
            return (navigate is null)
                ? _userService.GetAll(u => u.IsActive == true && u.DetailId!=null)
                : _userService.GetAll(u => u.IsActive == true && u.DetailId != null, true);
        }


        [HttpGet("Get/{id}")]
        public User Get(int id, int? navigate)
        {
            return (navigate is null)
                ? _userService.Get(u => u.Id == id && u.IsActive == true)
                : _userService.Get(u => u.Id == id && u.IsActive == true, true);
        }

        [HttpGet("Get/{email}/{password}")]
        public User Get(string eMail,string password)
        {
            return _userService.Get(u => u.MailAdress.Equals(eMail) && u.Password.Equals(password) && u.IsActive == true);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] User user)
        {
            if (_userService.Get(u => u.MailAdress.Equals(user.MailAdress) && u.IsActive == true) is null)
            {
                _userService.Add(user);
                return Ok(user);
            }
            return BadRequest("Mail adress already exist");
        }

        [HttpPatch("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.Get(u => u.Id == id && u.IsActive == true);
            if (user is not null)
            {
                user.IsActive = false;
                _userService.Update(user);
                return NoContent();
            }
            return BadRequest("User not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(User user)
        {
            var updateUser = _userService.Get(u => u.Id == user.Id && u.IsActive == true,true);
            if (updateUser is not null)
            {
                updateUser.Detail.FirstName = user.Detail.FirstName;
                updateUser.Detail.LastName = user.Detail.LastName;
                updateUser.Detail.MiddleName = user.Detail.MiddleName;
                _userService.Update(updateUser);
                return Ok(updateUser);
            }
            return BadRequest("User not found");
        }
        [HttpPatch("ChangePassword/{id}/{password}")]
        public ActionResult ChangePassword(int id, string password)
        {
            var updateUser = _userService.Get(u => u.Id == id && u.IsActive == true, true);
            if (updateUser is not null)
            {
                updateUser.Password = password;
                _userService.Update(updateUser);
                return Ok(updateUser);
            }
            return BadRequest("User not found");
        }
    }
}
