using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        public OrderList OrderList = new OrderList();

        public ActionResult Index()
        {
            // wanneer dit null is geen foutmelding vraag?
            // if sessionstring

            string sessionString = HttpContext.Session.GetString("CustomerSession");
            Customer customerSession = JsonConvert.DeserializeObject<Customer>(sessionString);

            if (customerSession != null)
            {
                var orders = OrderList.GetOrderList(customerSession.CustomerID);

                List<OrderViewModel> orderViewModelList = new List<OrderViewModel>();

                foreach (var order in orders)
                {
                    OrderViewModel ordVM = new OrderViewModel();

                    ordVM.OrderItemId = order.OrderItemID;
                    ordVM.ProductName = order.ProductName;
                    ordVM.Price = order.Price;
                    ordVM.Size = order.Size;
                    ordVM.Quantity = order.Quantity;
                    orderViewModelList.Add(ordVM);
                }

                ViewBag.Order = orderViewModelList;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
