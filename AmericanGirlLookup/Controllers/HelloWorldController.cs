using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace AmericanGirlLookup.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome(string name, int age)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}! You are {age} years old!");
        }
    }
}
