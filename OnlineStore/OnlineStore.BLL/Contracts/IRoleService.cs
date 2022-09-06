using Microsoft.AspNetCore.Mvc;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts
{
    public interface IRoleService
    {
        public ActionResult<Role> createRole(Role role);

        public ActionResult<Role> updateRole(int id, Role role);

        public ActionResult<Role> deleteRole(int id);

        public ActionResult<Role> getRole(int id);

        public ActionResult<IEnumerable<Role>> getRoles();

    }
}
