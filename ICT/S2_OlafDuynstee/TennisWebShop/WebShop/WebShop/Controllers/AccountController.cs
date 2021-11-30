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
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterAccount(RegisterViewModel regVM)
        {
            if (ModelState.IsValid)
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
            else
            {
                return View("Register", regVM);
            }
        }

        public IActionResult Login(LoginViewModel logVM)
        {
            
            
            return View();
        }
    }
}
