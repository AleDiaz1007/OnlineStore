using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        // Endpoint to get all users
        [HttpGet ("/getUsers")]
        public ActionResult<IEnumerable<Users>> getUsers()
        {
            return _service.getUsers();
        }

        // Endpoint to get one specific user
        [HttpGet ("/getUser/{id}")]
        public ActionResult<Users> getUser(int id)
        {
            return _service.getUser(id);
        }

        // Endpoint to create a user
        [HttpPost ("/createUser")]
        public ActionResult<Users> createUser(Users user)
        {
            return _service.createUser(user);
        }

        // Endpoint to update a user
        [HttpPut ("/updateUser/{id}")]
        public ActionResult<Users> updateUser(int id, Users user)
        {
            return _service.updateUser(id, user);   
        }

        // Endpoint to delete a user
        [HttpDelete ("/deleteUser/{id}")]
        public ActionResult<Users> deleteUser(int id)
        {
            return _service.deleteUser(id);
        }
    }
}
