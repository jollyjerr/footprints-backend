using System;
using System.ComponentModel.DataAnnotations;

namespace footprints.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength =4, ErrorMessage = "You must specify a password between 4 and 30 characters.")]
        public string Password { get; set; }
    }
}