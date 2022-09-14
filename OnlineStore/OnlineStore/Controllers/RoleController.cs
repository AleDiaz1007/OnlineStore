using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        // Endpoint to get all roles
        [HttpGet ("/getRoles")]
        public ActionResult<IEnumerable<Role>> getRoles()
        {
            var roles = _service.getRoles();

            if(roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        // Endpoint to get a specific role
        [HttpGet ("/getRole/{id}")]
        public ActionResult<Role> getRole(int id)
        {
            return _service.getRole(id);
        }

        // Endpoint to create a role
        [HttpPost ("/createRole")]
        public ActionResult<Role> createRole(Role role)
        {
            return _service.createRole(role);
        }

        // Endpoint to update a role
        [HttpPut ("/updateRole/{id}")]
        public ActionResult<Role> updateRole(int id, Role role)
        {
            return _service.updateRole(id, role);
        }

        // Endpoint to delete a role
        [HttpDelete ("/deleteRole/{id}")]
        public ActionResult<Role> deleteRole(int id)
        {
            return _service.deleteRole(id);
        }
    }
}
