using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ModelInterface
{
    public interface IRegister
    {
        int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password name is required")]
        [DataType(DataType.Password)]
        string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password name is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword shoud be same.")]
        string ConfirmPassword { get; set; }
    }
}
