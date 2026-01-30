using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.UserDto
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is Required. ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required. ")]
        public string Password { get; set; }
    }
}
