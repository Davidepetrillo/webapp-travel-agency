using Microsoft.AspNetCore.Mvc;
using TravelAgencyWebApp.Data;
using TravelAgencyWebApp.Models;

namespace TravelAgencyWebApp.Controllers
{
    public class TripController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            List<Trip> trips = new List<Trip>();

            using (TripContext database = new TripContext())
            {
             trips = database.Trips.ToList<Trip>();
            }

            return View("HomePage", trips);
        }

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

                } catch(Exception ex)
                {
                    return BadRequest();
                }

            }
                
            
            
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("FormTrip");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trip newTrip)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPost", newTrip);
            }

            using(TripContext database = new TripContext())
            {
                Trip newTripToCreate = new Trip(newTrip.Image, newTrip.Title, newTrip.Description, newTrip.Length, newTrip.Price);
                database.Trips.Add(newTripToCreate);
                database.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Trip tripToEdit = null;

            using (TripContext database = new TripContext())
            {
                tripToEdit = database.Trips
                    .Where(trip => trip.Id == id).FirstOrDefault();
            }

            if (tripToEdit == null)
            {
                return NotFound();
            }
            else
            {
                return View("Update", tripToEdit);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id, Trip model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            Trip tripOriginal = null;

            using (TripContext database = new TripContext())
            {
                tripOriginal = database.Trips.Where(trip => trip.Id == id).FirstOrDefault();

                if (tripOriginal != null)
                {
                    tripOriginal.Image = model.Image;
                    tripOriginal.Title = model.Title;
                    tripOriginal.Description = model.Description;
                    tripOriginal.Length = model.Length;
                    tripOriginal.Price = model.Price;

                    database.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound();
                }
            }
            
        }


        [HttpPost]

        public IActionResult Delete(int id)
        {
            using (TripContext database = new TripContext())
            {
                Trip tripToDelete = database.Trips.Where(trip => trip.Id == id).FirstOrDefault();

                if (tripToDelete != null)
                {
                    database.Trips.Remove(tripToDelete);
                    database.SaveChanges();

                    return RedirectToAction("Index");

                } else
                {
                    return NotFound();
                }

            }

        }

           
    }
}
