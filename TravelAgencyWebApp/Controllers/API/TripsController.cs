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


        [HttpGet("{id}")]
        
        public IActionResult Details(int id)
        {
            using (TripContext database = new TripContext())
            {
                try
                {
                    Trip tripFound = database.Trips
                        .Where(trip => trip.Id == id)
                        .FirstOrDefault();

                    return Ok(tripFound);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound($"Il viaggio con l'Id {id} non è stato trovato");

                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }



    }
}
