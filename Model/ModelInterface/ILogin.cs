using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ModelInterface
{
    public interface ILogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password name is required")]
        [DataType(DataType.Password)]
        string Password { get; set; }
    }
}
