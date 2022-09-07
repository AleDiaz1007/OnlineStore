using Microsoft.AspNetCore.Mvc;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Contracts
{
    public interface IUsersRepository
    {
        public ActionResult<IEnumerable<Users>> getUsers();

        public ActionResult<Users> getUser(int id);

        public ActionResult<Users> createUser(Users user);

        public ActionResult<Users> updateUser(int id, Users user);

        public ActionResult<Users> deleteUser(int id);
    }
}
