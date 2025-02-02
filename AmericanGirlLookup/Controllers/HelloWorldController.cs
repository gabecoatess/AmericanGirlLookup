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
        public IActionResult AuthorizationTest()
        {
            ViewData["AuthMessage"] = "You are authorized!";
            return View("AuthTestPage");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AdminTest()
        {
            ViewData["AuthMessage"] = "You are an administrator!";
            return View("AuthTestPage");
        }

        [Authorize(Roles = "Moderator,Administrator")]
        public IActionResult ModeratorTest()
        {
            ViewData["AuthMessage"] = "You are a moderator!";
            return View("AuthTestPage");
        }

        [Authorize(Roles = "Doll Curator,Administrator")]
        public IActionResult DollCuratorTest()
        {
            ViewData["AuthMessage"] = "You are a doll curator!";
            return View("AuthTestPage");
        }

        [Authorize(Roles = "Member,Doll Curator,Moderator,Administrator")]
        public IActionResult MemberTest()
        {
            ViewData["AuthMessage"] = "You are a member!";
            return View("AuthTestPage");
        }
    }
}
