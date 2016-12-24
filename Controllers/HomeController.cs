using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() {
            ViewBag.Message = "Home View - Powered by ASP.NET Core";
            return View();
        }
     
        public IActionResult About() {
            ViewBag.Message = "About View - Powered by ASP.NET Core";
            return View();
        }
    }
}