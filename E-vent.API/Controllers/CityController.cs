using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;

        public CityController()
        {
            _cityService = new CityManager(new CityDal());
        }

        [HttpGet("GetAllCities")]
        public List<City> GetAllCities()
        {
            return _cityService.GetAll(c => c.IsActive);
        }

        [HttpGet("GetCity")]
        public City GetCity(int cityId)
        {
            return _cityService.Get(c => c.Id == cityId && c.IsActive);
        }

        [HttpPost("AddCity")]
        public ActionResult AddCity([FromBody] City city)
        {
            if (_cityService.Get(c => c.Name.Equals(city.Name) && c.IsActive) is null)
            {
                _cityService.Add(city);
                return Ok();
            }
            return BadRequest("City name already exist, please enter another city name");
        }

        [HttpPut("DeleteCity")]
        public ActionResult DeleteCity(int cityId)
        {
            var city = _cityService.Get(d => d.Id == cityId && d.IsActive);
            if (city is not null)
            {
                city.IsActive = false;
                _cityService.Update(city);
                return Ok(city);
            }
            return BadRequest("City not found");
        }

        [HttpPut("UpdateCity")]
        public ActionResult UpdateCity(City city)
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
