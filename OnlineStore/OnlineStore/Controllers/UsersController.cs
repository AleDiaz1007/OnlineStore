using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        // Endpoint to get all users
        [HttpGet]
        public ActionResult<IEnumerable<Users>> getUsers()
        {
            var users = _service.getUsers();

            if(users == null)
            {
                return NotFound("There's no users stored");
            }

            return users;
        }

        // Endpoint to get one specific user
        [HttpGet ("{id}")]
        public ActionResult<Users> getUser(int id)
        {
            var selectedUser = _service.getUser(id);

            if(selectedUser == null)
            {
                return NotFound("Selected user not found");
            }

            return selectedUser;
        }

        // Endpoint to create a user
        [HttpPost ("create")]
        public ActionResult<Users> createUser(Users user)
        {
            var createdUser = _service.createUser(user);

            if(createdUser == null)
            {
                return NotFound("There's an error with user creation, " +
                    "it could be the idRole");
            }

            return createdUser;
        }

        // Endpoint to update a user
        [HttpPut ("{id}/update")]
        public ActionResult<Users> updateUser(int id, Users user)
        {
            var updatedUser = _service.updateUser(id, user);   

            if(updatedUser == null)
            {
                return NotFound("Selected user not found or the idRole is not valid");
            }

            return updatedUser;
        }

        // Endpoint to delete a user
        [HttpDelete ("{id}/delete")]
        public ActionResult<Users> deleteUser(int id)
        {
            return _service.deleteUser(id);
        }
    }
}
