using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Logic;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
                    return RedirectToAction("Login", "Account");
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

        public IActionResult Login()
        {
            LoginViewModel logModel = new LoginViewModel();
            return View(logModel);
        }

        [HttpPost]
        public IActionResult LoginCustomer(LoginViewModel logVM)
        {
            if (ModelState.IsValid)
            {
                CustomerCollection customerCollection = new CustomerCollection();
                Customer loginCustomer = new Customer();
                loginCustomer.CustomerEmail= logVM.CustomerEmail;
                loginCustomer.CustomerPassword = logVM.CustomerPassword;

                var customer = customerCollection.LoginCustomer(loginCustomer);

                if (customer.LoggedIn == true)
                {
                    // set the value into a session key
                    HttpContext.Session.SetString("CustomerSession", JsonConvert.SerializeObject(customer));
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return RedirectToAction("Login", logVM);
                }
            }
            else
            {
                return RedirectToAction("Login", logVM);
            }
        }

        public IActionResult LogoutCustomer()
        {
            HttpContext.Session.Remove("CustomerSession");
            return RedirectToAction("Login", "Account");
        }

        public IActionResult ChangePassword()
        {
            ChangePasswordViewModel cpVM = new ChangePasswordViewModel();
            return View(cpVM);
        }

        public IActionResult ChangePasswordAction(ChangePasswordViewModel cpVM)
        {
            if (ModelState.IsValid)
            {
                string newPassword = cpVM.CustomerNewPassword;
                
                CustomerCollection customerCollection = new CustomerCollection();
                var customerSession =
                    JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("CustomerSession"));
                
                string password = cpVM.CustomerPassword;
                string email = customerSession.CustomerEmail;

                var changeSuccessful = customerCollection.ChangePassword(email,password,  newPassword);
                if (changeSuccessful == true)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account");
                }
            }
            else
            {
                return RedirectToAction("ChangePassword", "Account");
            }
            
        }
    }
}
