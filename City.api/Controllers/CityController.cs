using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using City.api;
using City.api.Models;

namespace City.api.Controllers
{
    [Route("Api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CityDto> GetCities()
        {
            return Ok(CitiesDataStore.current);
        }
        [HttpGet("{Id}")]
        public ActionResult<CityDto> GetCityById(int id)
        {
            var City = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == id);

            if(City == null) 
            {
                return NotFound();
            }

            return Ok(City);
        }
    }
}
