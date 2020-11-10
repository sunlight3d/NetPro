using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnnotationsExample.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Full Name:")]
        [Required(ErrorMessage = "Please enter your name.")]
        public string FullName { get; set; }
        
        [Display(Name = "Email Address:")]
        public string Email { get; set; }

        [Display(Name = "Birthdate:")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
