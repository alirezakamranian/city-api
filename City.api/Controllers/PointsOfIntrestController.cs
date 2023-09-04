using City.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace City.api.Controllers
{
    [Route("api/city/{cityId}/pointsofIntrest")]
    [ApiController]
    public class PointsOfIntrestController : ControllerBase
    {
        private readonly ILogger<PointsOfIntrestController> _logger;
        public PointsOfIntrestController(ILogger<PointsOfIntrestController> logger)
        {
            _logger = logger;
        }
        #region GetAll
        [HttpGet()]
        public ActionResult<ICollection<PointsOfIntrestDto>> GetPointsOfIntrest(int cityId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city==null) 
            {
                return NotFound();
            }
            _logger.LogCritical("hmmmmmmmmm");
            return Ok(city.PointsOfIntrest);
        }
        #endregion

        #region GetById
        [HttpGet("{pointOfIntrestId}",Name = "GetPointOfIntrest")]
        public ActionResult<ICollection<PointsOfIntrestDto>> GetPointOfIntrest(int cityId,int pointOfIntrestId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var point = city.PointsOfIntrest.FirstOrDefault(p => p.Id == pointOfIntrestId);
            if(point==null)
            {
                return NotFound();
            }
            return Ok(point);
        }
        #endregion

        #region post
        [HttpPost]
        public ActionResult<PointsOfIntrestDto> CreatePointofIntrest(int cityId,[FromBody] PointsOfIntrestForCreateDto pointOfIntrest)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);

            if(city==null ) 
            {
                return NotFound();
            }

            var upperPoiId = CitiesDataStore.current.Cities.SelectMany(c => c.PointsOfIntrest).Max(p => p.Id);
            var createPoint = new PointsOfIntrestDto()
            {
                Id=++upperPoiId,
                Name=pointOfIntrest.Name,
                Description=pointOfIntrest.Description
            };
            city.PointsOfIntrest.Add(createPoint);

            return CreatedAtAction("GetPointOfIntrest",
                new
                {
                    cityId = cityId,
                    pointOfIntrestId = createPoint.Id
                },
                createPoint
                ) ;
        }
        #endregion

        #region Put
        [HttpPut("{pointOfIntrestId}")]
        public ActionResult UpdatePointOfIntrest(int cityId,int pointOfIntrestId,[FromBody]PointsOfIntrestForUpdateDto pointOfIntrest)
        {
            var city =CitiesDataStore.current.Cities.FirstOrDefault(c=>c.Id == cityId);
            if(city==null)
            {
                return NotFound();
            }

            var poi=city.PointsOfIntrest.FirstOrDefault(p=>p.Id==pointOfIntrestId);
            if(poi==null)
            {
                return NotFound();
            }
            poi.Name=pointOfIntrest.Name;
            poi.Description = pointOfIntrest.Description;
            return NoContent();
        }

        #endregion
    }
}
