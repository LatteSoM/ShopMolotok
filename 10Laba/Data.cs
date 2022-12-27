using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class Data
    {
        public string Role;
        public string Login;
        public string Password;
        public int ID;
        public Data(string role, string login, string password, int id)
        {
            Role = role;
            Login = login;
            Password = password;
            ID = id;
        }
    }
}
