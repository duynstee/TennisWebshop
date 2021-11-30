using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string CustomerPhoneNumber { get; set; }
    }
}
