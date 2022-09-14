using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Context;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        readonly DbContextOptions<OnlineStoreContext> _optionsBuilder;

        public RoleRepository(DbContextOptions<OnlineStoreContext> context)
        {
            _optionsBuilder = context;
        }

        public ActionResult<IEnumerable<Role>> getRoles()
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                List<Role> rolesList = db.Role.Select(x => x).ToList();

                if(rolesList.Any())
                {
                    return rolesList;
                }

                return null; 
            }
        }

        public ActionResult<Role> getRole(int id)
        {
            using (var db = new OnlineStoreContext(_optionsBuilder))
            {
                Role role = db.Role.FirstOrDefault(role => role.Id == id);

                if(role != null)
                {
                    return role;
                }

                return null;
            }
        }

        public ActionResult<Role> createRole(Role role)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                if(role != null)
                {
                    db.Role.Add(role);
                    db.SaveChanges();

                    return role;
                }

                return null;
                
            }
        }

        public ActionResult<Role> updateRole(int id, Role role)
        {
            using (var db = new OnlineStoreContext(_optionsBuilder))
            {
                Role query = db.Role.FirstOrDefault(r => r.Id == id);

                if (query != null)
                {

                    query.Name = role.Name;

                    db.SaveChanges();

                    return role;
                }

                return null;

            }
        }

        public ActionResult<Role> deleteRole(int id)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Role roleToRemove = db.Role.FirstOrDefault(role => role.Id == id);

                if(roleToRemove != null)
                {
                    db.Role.Remove(roleToRemove);
                    db.SaveChanges();

                    return roleToRemove;
                }

                return null;

            }
        }
    }
}
