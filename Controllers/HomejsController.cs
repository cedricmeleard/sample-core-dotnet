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
     

        [HttpGet]
        [Route("api/[controller]/home")]
        public string GetHome()
        {
            return "Home View - Powered by ASP.NET Core";
        }
        [HttpGet]
        [Route("api/[controller]/about")]
        public string GetAbout()
        {
            return "About View - Powered by ASP.NET Core";
        }
    }
}