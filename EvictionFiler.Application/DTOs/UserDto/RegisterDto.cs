using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.UserDto
{
    public class RegisterDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string? LastName { get; set; } 
        public string? MiddleName { get; set; }
       


        
        public string Email { get; set; } = "";

       
        public string Password { get; set; } = "";

        public string? Phone { get; set; }
        public string ConfirmPassword { get; set; } = "";
        public string Role { get; set; } = "Admin";
        public Guid? SubscriptionId { get; set; } 
        public Guid? FirmId { get; set; }

        //Added
        public Guid? SubscriptionTypeId { get; set; }
        public string? SubscriptionName { get; set; }
    }
}
