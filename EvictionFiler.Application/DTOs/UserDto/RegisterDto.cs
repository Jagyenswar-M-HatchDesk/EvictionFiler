﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.UserDto
{
    public class RegisterDto
    {

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
