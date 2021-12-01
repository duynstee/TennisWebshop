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
                Customer _customer = new Customer();
                _customer.CustomerEmail = logVM.CustomerEmail;
                _customer.CustomerPassword = logVM.CustomerPassword;
                
                var customer = customerCollection.LoginCustomer(_customer);

                if (customer.LoggedIn == true)
                {
                    HttpContext.Session.SetInt32("CustomerID", customer.CustomerID);
                    HttpContext.Session.SetString("CustomerName", customer.CustomerName);
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

    }
}
