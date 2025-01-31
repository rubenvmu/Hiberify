using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webmusic_solved.Models;
using webmusic_solved.Services.CounterSQL;

namespace webmusic_solved.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountersqlService _countersqlService;

        public HomeController(ILogger<HomeController> logger, ICountersqlService countersqlService)
        {
            _logger = logger;
            _countersqlService = countersqlService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index page loaded");
            ViewBag.ArtistasCount = _countersqlService.GetArtistasCount();
            ViewBag.CancionesCount = _countersqlService.GetCancionesCount();
            ViewBag.MinutosMusicaCount = Math.Round(_countersqlService.GetCancionesCount() * 3.14m);
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy page loaded");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("An error occurred");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}