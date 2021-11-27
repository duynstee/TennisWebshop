using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        public OrderList OrderList = new OrderList();

        public ActionResult Index()
        {
            var orders = OrderList.GetOrderList();

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
    }
}
