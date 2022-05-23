using Microsoft.AspNetCore.Mvc;
using TravelAgencyWebApp.Models;
using TravelAgencyWebApp.Models.Utils;

namespace TravelAgencyWebApp.Controllers
{
    public class TripController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Trip> trips = TripData.GetTrips();
            return View("HomePage", trips);
        }

        public IActionResult Details(int id)
        {
            Trip tripFound = GetTripById(id);

            if (tripFound != null)
            {
                return View("Details", tripFound);
            }
            else
            {
                return NotFound($"Il viaggio con l'Id {id} non è stato trovato");
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

            Trip newTripWithId = new Trip(TripData.GetTrips().Count, newTrip.Image, newTrip.Title, newTrip.Description, newTrip.Length, newTrip.Price);

            TripData.GetTrips().Add(newTripWithId);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Trip tripToEdit = GetTripById(id);

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

            Trip tripOriginal = GetTripById(id);

            if (tripOriginal != null)
            {
                tripOriginal.Image = model.Image;
                tripOriginal.Title = model.Title;
                tripOriginal.Description = model.Description;
                tripOriginal.Length = model.Length;
                tripOriginal.Price = model.Price;



                return RedirectToAction("Index");

            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]

        public IActionResult Delete(int id)
        {

            int TripIndexToRemove = -1;

            List<Trip> tripList = TripData.GetTrips();

            for (int i = 0; i < TripData.GetTrips().Count; i++)
            {

                if (tripList[i].Id == id)
                {
                    TripIndexToRemove = i;
                }
            }

            if (TripIndexToRemove != null)
            {
                TripData.GetTrips().RemoveAt(TripIndexToRemove);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }


        }

        private Trip GetTripById(int id)
        {

            Trip tripFound = null;

            foreach (Trip trip in TripData.GetTrips())
            {
                if (trip.Id == id)
                {
                    tripFound = trip;
                    break;
                }
            }

            return tripFound;
        }
    }
}
