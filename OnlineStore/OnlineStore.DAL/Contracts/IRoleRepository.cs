using Microsoft.AspNetCore.Mvc;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Contracts
{
    public interface IRoleRepository
    {
        public ActionResult<Role> createRole(Role role);

        public ActionResult<Role> updateRole(int id, Role role);

        public ActionResult<Role> deleteRole(int id);

        public ActionResult<Role> getRole(int id);

        public ActionResult<IEnumerable<Role>> getRoles();
    }
}
