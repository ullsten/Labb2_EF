using Microsoft.AspNetCore.Mvc;

namespace Labb2_EF.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
