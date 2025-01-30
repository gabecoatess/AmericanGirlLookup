using Microsoft.AspNetCore.Mvc;

namespace AmericanGirlLookup.Controllers
{
    public class DollLookup : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Doll(string dollName)
        {
            ViewData["DollName"] = dollName;

            return View();
        }
    }
}
