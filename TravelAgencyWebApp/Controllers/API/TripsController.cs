using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyWebApp.Data;
using TravelAgencyWebApp.Models;

namespace TravelAgencyWebApp.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Trip> trips = new List<Trip>();

            using (TripContext database = new TripContext())
            {
                trips = database.Trips.ToList<Trip>();
            }

            return Ok(trips);
        }


        
    }
}
