using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntegratorController : ControllerBase
    {
        private IEntegratorService _entegratorService;

        public EntegratorController()
        {
            _entegratorService = new EntegratorManager(new EntegratorDal());
        }

        [HttpGet("GetAll")]
        public List<Entegrator> GetAll()
        {
            return _entegratorService.GetAll(e => e.IsActive);
        }

        [HttpGet("Get")]
        public Entegrator Get(int entegratorId)
        {
            return _entegratorService.Get(e => e.Id == entegratorId && e.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Entegrator entegrator)
        {
            if (_entegratorService.Get(e => e.DomainName.Equals(entegrator.DomainName) && e.IsActive) is null)
            {
                _entegratorService.Add(entegrator);
                return Ok(entegrator);
            }
            return BadRequest("Entegrator already exist, please try again!");
        }

        [HttpPut("Delete")]
        public ActionResult Delete(int entegratorId)
        {
            var entegrator = _entegratorService.Get(e => e.Id == entegratorId && e.IsActive);
            if (entegrator is not null)
            {
                entegrator.IsActive = false;
                _entegratorService.Update(entegrator);
                return NoContent();
            }
            return BadRequest("City not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(Entegrator entegrator)
        {
            var updateEntegrator = _entegratorService.Get(e => e.Id == entegrator.Id && e.IsActive);
            if (updateEntegrator is not null)
            {
                updateEntegrator = _entegratorService.Get(e => e.DomainName.Equals(entegrator.DomainName));
                if (updateEntegrator is null)
                {
                    _entegratorService.Update(entegrator);
                    return Ok(entegrator);
                }
                return BadRequest("domain name already exist!");
            }
            return BadRequest("entegrator not found");
        }
    }
}
