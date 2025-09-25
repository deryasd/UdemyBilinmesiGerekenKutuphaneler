using Logging.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logging.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ILoggerFactory _loggerFactory;
        public HomeController(ILoggerFactory  loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public IActionResult Index()
        {
            _loggerFactory.CreateLogger("Home").LogTrace("Index page visited at {Time}", DateTime.UtcNow);

            //_logger.logtrace("ýndex page visited at {time}", datetime.utcnow);
            //_logger.logdebug("ýndex page visited at {time}", datetime.utcnow);
            //_logger.logýnformation("ýndex page visited at {time}", datetime.utcnow);
            //_logger.logwarning("ýndex page visited at {time}", datetime.utcnow);
            //_logger.logerror("ýndex page visited at {time}", datetime.utcnow);
            //_logger.logcritical("ýndex page visited at {time}", datetime.utcnow);
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
