using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() {
            ViewBag.Message = "Powered by ASP.NET Core";
            return View();
        }
    }
}