using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelAgencyWebApp.Models;

namespace TravelAgencyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string SearchString)
        {
            return View();
        }

    }
}