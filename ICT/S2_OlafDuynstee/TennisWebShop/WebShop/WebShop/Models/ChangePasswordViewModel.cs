using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Fill in password")]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage = "Fill in new password")]
        public string CustomerNewPassword { get; set; }
    }
}
