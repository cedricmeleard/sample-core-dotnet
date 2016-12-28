using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp.Controllers
{
    public class HomejsController : Controller
    {
        [Route("/Homejs/")]
        [Route("/Homejs/Index")]
        [Route("/Homejs/About")]
        public IActionResult Index() {
            ViewBag.Message = "Home JS View";
            return View();
        }
    }
}