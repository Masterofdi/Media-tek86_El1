using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_tek86.model
{
    internal class Admin
    {
        public string Login { get; }
        public string Pwd { get; }

        public Admin(string login, string pwd)
        {
            Login = login;
            Pwd = pwd;
        }
    }
}
 