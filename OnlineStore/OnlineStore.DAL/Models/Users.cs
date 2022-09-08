using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Models
{
    public class Users
    {
        public int id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int IdRole { get; set; }

    }
}
