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
        public List<City> GetAll(int? navigate)
        {
            return (navigate is null)
                ? _cityService.GetAll(c => c.IsActive)
                : _cityService.GetAll(c => c.IsActive, true);
        }

        [HttpGet("Get/{id}")]
        public City Get(int id, int? navigate)
        {
            return (navigate is null)
          ? _cityService.Get(c => c.Id == id && c.IsActive)
          : _cityService.Get(c => c.Id == id && c.IsActive, true);
        }


        [HttpPost("Add")]
        public ActionResult Add([FromBody] City city)
        {
            if (_cityService.Get(c => c.Name.Equals(city.Name) && c.IsActive) is null)
            {
                city.IsActive = true;
                _cityService.Add(city);
                return Ok(city);
            }
            return BadRequest("City name already exist, please enter another city name");
        }


        [HttpPatch("Delete/{id}")]
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
        public ActionResult Update([FromBody] City city)
        {
            var updateCity = _cityService.Get(c => c.Name.Equals(city.Name));
            if (updateCity is null)
            {
                updateCity = _cityService.Get(c => c.Id == city.Id && c.IsActive);
                if (updateCity is not null)
                {
                    updateCity.Name = city.Name;
                    _cityService.Update(updateCity);
                    return Ok(updateCity);
                }
                return BadRequest("City not found");
            }
            return BadRequest("City name already exist!");
        }
    }
}
