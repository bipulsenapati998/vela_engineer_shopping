using BLL.UserAccount;
using DataAccessLayer.FactoryShoppingModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FactoryShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userService;
        public UserController(IUserRepository _userService)
        {
            userService = _userService;
        }
        // Post: /api/User/saveUser
        [HttpPost("saveUser")]
        public bool saveUser(User user)
        {
            return userService.saveUser(user);
        }


        // GET: api/User
        [HttpGet]
        public List<User> GetUsers()
        {
            return userService.getAllUsers();
        }

        // GET: api/User/id
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userService.getUserById(id);
        }

        // PUT: api/User/5
        [HttpPut]
        public bool Put(User value)
        {
            return userService.updateUser(value.UserId, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return userService.deleteuserbyId(id);
        }
    }
}
