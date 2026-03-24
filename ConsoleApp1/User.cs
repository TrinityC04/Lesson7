using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class User
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public User(string email, bool isActive)
        {
            Email = email;
            IsActive = isActive;
        }
    }
}
