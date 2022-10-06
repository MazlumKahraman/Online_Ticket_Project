﻿using E_vent.Business.Abstract;
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

        [HttpGet("GetAllEntegrators")]
        public List<Entegrator> GetAllEntegrators()
        {
            return _entegratorService.GetAll(e => e.IsActive);
        }

        [HttpGet("GetEntegrator")]
        public Entegrator GetEntegrator(int entegratorId)
        {
            return _entegratorService.Get(e => e.Id == entegratorId && e.IsActive);
        }

        [HttpPost("AddEntegrator")]
        public ActionResult AddEntegrator([FromBody] Entegrator entegrator)
        {
            if (_entegratorService.Get(e => e.DomainName.Equals(entegrator.DomainName) && e.IsActive) is null)
            {
                _entegratorService.Add(entegrator);
                return Ok();
            }
            return BadRequest("Entegrator already exist, please try again!");
        }

        [HttpPut("DeleteEntegrator")]
        public ActionResult DeleteEntegrator(int entegratorId)
        {
            var entegrator = _entegratorService.Get(e => e.Id == entegratorId && e.IsActive);
            if (entegrator is not null)
            {
                entegrator.IsActive = false;
                _entegratorService.Update(entegrator);
                return Ok(entegrator);
            }
            return BadRequest("City not found");
        }

        [HttpPut("UpdateEntegrator")]
        public ActionResult UpdateEntegrator(Entegrator entegrator)
        {
            var updateEntegrator = _entegratorService.Get(e => e.Id == entegrator.Id && e.IsActive);
            if (updateEntegrator is not null)
            {
                updateEntegrator = _entegratorService.Get(e => e.DomainName.Equals(entegrator.DomainName));
                if (updateEntegrator is null)
                {
                    _entegratorService.Update(entegrator);
                    return Ok();
                }
                return BadRequest("domain name already exist!");
            }
            return BadRequest("entegrator not found");
        }
    }
}
