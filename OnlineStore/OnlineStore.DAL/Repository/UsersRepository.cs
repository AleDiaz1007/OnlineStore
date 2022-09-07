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
    public class UsersRepository : IUsersRepository
    {
        readonly DbContextOptions<OnlineStoreContext> _optionsBuilder;

        public UsersRepository(DbContextOptions<OnlineStoreContext> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public ActionResult<IEnumerable<Users>> getUsers()
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                List<Users> usersList = db.Users.Select(x => x).ToList();

                if (usersList != null)
                {

                    return usersList ;

                }

                return null;

            }
        }

        public ActionResult<Users> getUser(int id)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Users selectedUser = db.Users.FirstOrDefault(x => x.id == id);

                if(selectedUser != null)
                {
                    return selectedUser;
                }

                return null;
            }
        }

        public ActionResult<Users> createUser(Users user)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Role validateRole = db.Role.FirstOrDefault(x => x.Id == user.IdRole);

                if(validateRole != null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    return user;
                }

                return null;

            }
        }

        public ActionResult<Users> updateUser(int id, Users user)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Users userToUpdate = db.Users.FirstOrDefault(x => x.id == id);

                Role validateRole = db.Role.FirstOrDefault(x => x.Id == user.IdRole);

                if(validateRole != null && userToUpdate != null)
                {
                    userToUpdate.Email = user.Email;
                    userToUpdate.IdRole = user.IdRole;
                    userToUpdate.Password = user.Password;

                    db.SaveChanges();

                    return userToUpdate;
                }

                return null;

            }
        }

        public ActionResult<Users> deleteUser(int id)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Users userToDelete = db.Users.FirstOrDefault(x =>x.id == id);

                if(userToDelete != null)
                {
                    db.Users.Remove(userToDelete);

                    db.SaveChanges();

                    return userToDelete;
                }

                return null;

            }
        }
    }
}
