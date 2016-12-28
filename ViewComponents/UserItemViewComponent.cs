using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace aspnetcoreapp.ViewComponents
{
    public class UserItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(
        UserItem user)
        {
            return View(user);
        }
    }
}