using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Context;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class UsersService : IUsersService
    {
        readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public ActionResult<IEnumerable<Users>> getUsers()
        {
            return _repository.getUsers();
        }

        public ActionResult<Users> getUser(int id)
        {
            return _repository.getUser(id);
        }

        public ActionResult<Users> createUser(Users user)
        {
            return _repository.createUser(user);
        }

        public ActionResult<Users> updateUser(int id, Users user)
        {
            return _repository.updateUser(id, user);
        }

        public ActionResult<Users> deleteUser(int id)
        {
            return _repository.deleteUser(id);
        }

    }
}
