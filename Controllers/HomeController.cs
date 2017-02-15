using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace aspnetcoreapp.Controllers
{
    public class HomeController : Controller
    {

        public IUserRepository UserRepository { get; set; }

        public HomeController(IUserRepository userItems){
           UserRepository = userItems;
        }


        public IActionResult Index([FromQuery]string Search) {
            ViewBag.Message = "Home View - Powered by ASP.NET Core";
            ViewBag.Users = UserRepository.GetAll(Search);
            ViewBag.Search = "";
            return View();
        }
     
        public IActionResult About() {
            ViewBag.Message = "About View - Powered by ASP.NET Core";
            return View();
        }
    }
}