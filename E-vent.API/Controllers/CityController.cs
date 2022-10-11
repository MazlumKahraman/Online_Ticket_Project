using E_vent.API.Helpers.Attributes;
using E_vent.Business.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetAll")]
        public List<City> GetAll()
        {
            return _cityService.GetAll(c => c.IsActive);
        }

        [HttpGet("Get/{id}")]
        public City Get(int id)
        {
            return _cityService.Get(c => c.Id == id && c.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] City city)
        {
            if (_cityService.Get(c => c.Name.Equals(city.Name) && c.IsActive) is null)
            {
                _cityService.Add(city);
                return Ok(city);
            }
            return BadRequest("City name already exist, please enter another city name");
        }

        [HttpPut("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var city = _cityService.Get(d => d.Id == id && d.IsActive);
            if (city is not null)
            {
                city.IsActive = false;
                _cityService.Update(city);
                return NoContent();
            }
            return BadRequest("City not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(City city)
        {
            var updateCity = _cityService.Get(d => d.Id == city.Id && d.IsActive);
            if (updateCity is not null)
            {
                updateCity = _cityService.Get(c => c.Name.Equals(city.Name));
                if (updateCity is null)
                {
                    _cityService.Update(city);
                    return Ok();
                }
                return BadRequest("City name already exist!");
            }
            return BadRequest("City not found");
        }
    }
}
