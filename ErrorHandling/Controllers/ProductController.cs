using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
