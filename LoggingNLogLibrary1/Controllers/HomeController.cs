using LoggingNLogLibrary1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingNLogLibrary1.Controllers
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
            int value1 = 5;
            int value2 = 0;
            try
            {
                int result = value1 / value2;
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError(ex, "Attempted to divide by zero. Value1: {Value1}, Value2: {Value2}", value1, value2);
            }


            _logger.LogInformation("This is an informational message.");
            _logger.LogWarning("This is a warning message.");
            _logger.LogError("This is an error message.");
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
