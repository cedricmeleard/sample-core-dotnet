using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
         
        public UserController(IUserRepository userItems)
        {
            UserItems = userItems;
        }

        [HttpGet]
        public IEnumerable<UserItem> GetAll()
        {
            return UserItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            var user = UserItems.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        public IUserRepository UserItems { get; set; }
    }
}