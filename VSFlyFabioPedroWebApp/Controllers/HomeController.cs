using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VSFlyFabioPedroWebApp.Models;
using VSFlyFabioPedroWebApp.Services;

namespace VSFlyFabioPedroWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVSFlyFabioPedroServices _vsFlyFabioPedroService; 

        public HomeController(ILogger<HomeController> logger, IVSFlyFabioPedroServices vSFlyFabioPedroServices)
        {
            _logger = logger;
            _vsFlyFabioPedroService = vSFlyFabioPedroServices;
        }

        public async Task<IActionResult> Index()
        {
            var passagerListe = await _vsFlyFabioPedroService.GetPassagers();
            return View(passagerListe);
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