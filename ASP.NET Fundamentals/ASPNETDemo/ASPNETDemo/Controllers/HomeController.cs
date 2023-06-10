using ASPNETDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello from Visuaal Studio!";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app.";
            ViewBag.Text = "This is the About page for our first ASP.NET Core MVC app.";
            return View();
        }

        public IActionResult Numbers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = 5)
        {
            ViewBag.Count = count;
            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewBag.Count = 1;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}