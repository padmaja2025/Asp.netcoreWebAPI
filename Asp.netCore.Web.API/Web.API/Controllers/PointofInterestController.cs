using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

            if (city == null)
            {
                return NotFound();

            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{PointofInterestId}", Name = "GetPointofInterest")]
        public ActionResult<PointofInterestDto> GetPointofInterest(int cityid, int PointofInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null)
            {
                return NotFound();
            }

            var PointofInterest = city.PointsOfInterest.FirstOrDefault(p => p.id == PointofInterestId);
            if (PointofInterest == null)
            {
                return NotFound();
            }
            return Ok(PointofInterest);
        }

        [HttpPost]
        public ActionResult<PointofInterestDto> PointofInterestCreation(PointofInterestofCreationDto pointofinterestcreationdto, int cityid)
        {
            var City = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);

            if (City == null)
            {
                return NotFound();
            }

            var maxidofpointofinterest = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.id);

            var addpointofinterest = new PointofInterestDto()
            {
                id = maxidofpointofinterest + 1,
                Name = pointofinterestcreationdto.Name,
                Description = pointofinterestcreationdto.Description
            };

            City.PointsOfInterest.Add(addpointofinterest);

            return CreatedAtRoute("GetPointofInterest", new
            {
                cityid = cityid,
                PointofInterestId = addpointofinterest.id
            }, addpointofinterest);

        }

        [HttpPut("{pointofinterestid}")]
        public ActionResult<PointofInterestDto> PointofInterestUpdate(int cityid, int pointofinterestid,PointofInterestofUpdateDto pointofinterestupdatedto)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null)
            {
                return NotFound();
            }
            var pointofinterest = city.PointsOfInterest.FirstOrDefault(p => p.id == pointofinterestid);

            if(pointofinterest == null)
            {
                return NotFound();
            }
            
            pointofinterest.Name = pointofinterestupdatedto.Name;
            pointofinterest.Description = pointofinterestupdatedto.Description;

            return NoContent();
        }

        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartiallyUpdatePointofInterest(int cityid,int pointofInterestId,
            JsonPatchDocument<PointofInterestofUpdateDto> patchDocument)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null)
            {
                return NotFound();
            }
            var pointofinterest = city.PointsOfInterest.FirstOrDefault(p => p.id == pointofInterestId);
            if (pointofinterest == null)
            {
                return NotFound();
            }
            var pointofInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.id == pointofInterestId);
            if(pointofInterestFromStore == null)
            {
                return NotFound();
            }

            var pointofInterestToPatch = new PointofInterestofUpdateDto()
            {
                Name = pointofInterestFromStore.Name,
                Description = pointofInterestFromStore.Description
            };

            patchDocument.ApplyTo(pointofInterestToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!TryValidateModel(pointofInterestToPatch))
            {
                return BadRequest(ModelState);
            }
            pointofInterestFromStore.Name = pointofInterestToPatch.Name;
            pointofInterestFromStore.Description = pointofInterestToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{pointofinterestid}")]
        public ActionResult DeletePointofInterest(int cityid,int pointofinterestid)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null)
            {
                return NotFound();
            }
            var pointofinterest = city.PointsOfInterest.FirstOrDefault(p => p.id == pointofinterestid);
            if (pointofinterest == null)
            {
                return NotFound();
            }
            city.PointsOfInterest.Remove(pointofinterest);
            return NoContent();

        }
    }
}
