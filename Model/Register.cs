using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Register : IRegister
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
