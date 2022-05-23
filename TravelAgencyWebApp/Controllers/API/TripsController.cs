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
        public IActionResult Get(string? search)
        {
            List<Trip> trips = new List<Trip>();

            using (TripContext database = new TripContext())
            {
                if (search != null && search != "")
                {
                    trips = database.Trips.Where(trip => trip.Title.Contains(search) || trip.Description.Contains(search)).ToList<Trip>();
                }
                else
                {
                    trips = database.Trips.ToList<Trip>();
                }

            }

            return Ok(trips);
        }


        
    }
}
