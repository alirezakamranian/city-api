using City.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace City.api.Controllers
{
    [Route("api/city/{cityId}/pointsofIntrest")]
    [ApiController]
    public class PointsOfIntrestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ICollection<PointsOfIntrestDto>> GetPointsOfIntrest(int cityId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city==null) 
            {
                return NotFound();
            }
            return Ok(city.PointsOfIntrest);
        }
    }
}
