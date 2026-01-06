using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Model;

namespace Web.API.Controllers
{
    [Route("api/cities/{cityid}/pointofinterest")]
    [ApiController]
    public class PointofInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointofInterestDto>> PointofInterest(int cityid)
        {
            var city = CitiesDataStore.Current.Cities.Find(c => c.Id == cityid);
                
            if(city == null)
            {
              return  NotFound();

            }
            return Ok(city.PointsOfInterest); 
        }

        [HttpGet("{PointofInterestId}", Name ="GetPointofInterest")]
        public ActionResult<PointofInterestDto> GetPointofInterest(int cityid,int PointofInterestId )
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null)
            {
             return NotFound();
            }
           
            var PointofInterest = city.PointsOfInterest.FirstOrDefault(p => p.id == PointofInterestId);
            if(PointofInterest == null)
            {
                return NotFound();
            }
            return Ok(PointofInterest);
        }
        [HttpPost]
        public ActionResult<PointofInterestDto> PointofInterestCreation(int CityId,[FromBody] PointofInterestofCreationDto pointofinterestcreationddto)
        {
            var City = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == CityId);

            if (City == null)
            {
                return NotFound();
            }

            var maxidofpointofinterest = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.id);

            var addpointofinterest = new PointofInterestDto()
            {
                id = maxidofpointofinterest + 1,
                Name = pointofinterestcreationddto.Name,
                Description = pointofinterestcreationddto.Description
            };

            City.PointsOfInterest.Add(addpointofinterest);

            return CreatedAtRoute("GetPointofInterest", new
            {
                cityid = CityId,
                PointofInterestId = addpointofinterest.id
            }, addpointofinterest);
           
        }
    }
}
