using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Wrong Email - Password combination")]
        public string CustomerEmail  { get; set; }
        [Required(ErrorMessage = "Wrong Email - Password combination")]
        public string CustomerPassword { get; set; }
    }
}
