using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController()
        {
            _userService = new UserManager(new UserDal());
        }

        [HttpGet("GetAll")]
        public List<User> GetAll()
        {
            return _userService.GetAll(u => u.IsActive);
        }

        [HttpGet("Get")]
        public User Get(int userId)
        {
            return _userService.Get(u => u.Id == userId && u.IsActive);
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

        [HttpPut("Delete")]
        public ActionResult Delete(int userId)
        {
            var user = _userService.Get(u => u.Id == userId && u.IsActive);
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
