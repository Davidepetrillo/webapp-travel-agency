using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelAgencyWebApp.Data;
using TravelAgencyWebApp.Models;

namespace TravelAgencyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string SearchString)
        {
            return View();
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            using (TripContext database = new TripContext())
            {
                try
                {
                    Trip tripFound = database.Trips
                        .Where(trip => trip.Id == id)
                        .FirstOrDefault();

                    return View("Details", tripFound);

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