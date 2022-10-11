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
        public List<User> GetAll()
        {
            return _userService.GetAll(u => u.IsActive);
        }

        [HttpGet("Get/{id}")]
        public User Get(int id)
        {
            return _userService.Get(u => u.Id == id && u.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] User user)
        {
            if (_userService.Get(u => u.MailAdress.Equals(user.MailAdress) && u.IsActive) is null)
            {
                _userService.Add(user);
                return Ok(user);
            }
            return BadRequest("Mail adress already exist");
        }

        [HttpPut("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.Get(u => u.Id == id && u.IsActive);
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
            var updateUser = _userService.Get(u => u.Id == user.Id && u.IsActive);
            if (updateUser is not null)
            {
                _userService.Update(user);
                return Ok(user);
            }
            return BadRequest("User not found");
        }
    }
}
