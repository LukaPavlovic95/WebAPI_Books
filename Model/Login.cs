using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Login : ILogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
