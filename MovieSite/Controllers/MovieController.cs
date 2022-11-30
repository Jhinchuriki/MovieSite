using Microsoft.AspNetCore.Mvc;

namespace MovieSite.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
    }
}
