using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string CustomerEmail  { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string CustomerPassword { get; set; }
    }
}
