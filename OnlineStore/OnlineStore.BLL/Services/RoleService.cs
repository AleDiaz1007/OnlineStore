using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class RoleService : IRoleService
    {
        readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repo) 
        { 
            _repository = repo; 
        }

        public ActionResult<IEnumerable<Role>> getRoles()
        {
            return _repository.getRoles();
        }

        public ActionResult<Role> getRole(int id)
        {
            return _repository.getRole(id);
        }

        public ActionResult<Role> createRole(Role role)
        {
            return _repository.createRole(role);
        }

        public ActionResult<Role> updateRole(int id, Role role)
        {
            return _repository.updateRole(id, role);
        }

        public ActionResult<Role> deleteRole(int id)
        {
            return _repository.deleteRole(id);
        }
    }
}
