using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("cities")]
        public ActionResult cities()
        {
            return Ok(CitiesDataStore.Current.Cities);
           
            
        }

        [HttpGet("cities/{id}")]
        public ActionResult GetCity(int id)
        {
         var City =    CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if(City == null)
            {
                return NotFound();
            }
            return Ok(City);
        }
    }
}
