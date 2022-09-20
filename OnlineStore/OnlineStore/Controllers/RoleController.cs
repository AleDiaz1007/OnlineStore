using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        // Endpoint to get all roles
        [HttpGet]
        public ActionResult<IEnumerable<Role>> getRoles()
        {
            var roles = _service.getRoles();

            if(roles == null)
            {
                return NotFound("There's no roles stored");
            }

            return roles;
        }

        // Endpoint to get a specific role
        [HttpGet ("{id}")]
        public ActionResult<Role> getRole(int id)
        {
            var selectedRole = _service.getRole(id);

            if(selectedRole == null)
            {
                return NotFound("Selected role not found");
            }

            return selectedRole;
        }

        // Endpoint to create a role
        [HttpPost ("create")]
        public ActionResult<Role> createRole(Role role)
        {
            return _service.createRole(role);
        }

        // Endpoint to update a role
        [HttpPut ("update/{id}")]
        public ActionResult<Role> updateRole(int id, Role role)
        {
            var updatedRole = _service.updateRole(id, role);

            if(updatedRole == null)
            {
                return NotFound("Selected role not found");
            }

            return updatedRole;
        }

        // Endpoint to delete a role
        [HttpDelete ("delete/{id}")]
        public ActionResult<Role> deleteRole(int id)
        {
            return _service.deleteRole(id);
        }
    }
}
