using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Logic;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterAccount(RegisterViewModel regVM)
        {
            CustomerCollection customerCollection = new CustomerCollection();
            
            Customer customer = new Customer();
            customer.CustomerEmail = regVM.CustomerEmail;
            customer.CustomerPassword = regVM.CustomerPassword;
            customer.CustomerName = regVM.CustomerName;
            customer.CustomerAddress = regVM.CustomerAddress;
            customer.CustomerPhoneNumber = regVM.CustomerPhoneNumber;

            if (customerCollection.CreateCustomer(customer) == true)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
