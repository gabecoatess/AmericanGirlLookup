using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

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

        [Authorize]
        public string AuthorizationTest()
        {
            return "You are authorized!";
        }
    }
}
