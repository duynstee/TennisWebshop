using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Logic;
using WebShop.Models;
using Newtonsoft.Json;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {

        public ProductCollection ProductCollection = new ProductCollection();

        public ActionResult Index()
        {
            var products = ProductCollection.GetProductList();

            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

            foreach (var product in products)
            {
                ProductViewModel prodVM = new ProductViewModel();
                prodVM.ProductId = product.ProductId;
                prodVM.ProductName = product.ProductName;
                prodVM.Size = product.Size;
                prodVM.Price = product.Price;
                prodVM.Quantity = product.Quantity;
                prodVM.Description = product.Description;
                productViewModelList.Add(prodVM);
            }

            ViewBag.Product = productViewModelList;
            return View();
        }

        //[HttpGet("{productId:int}")]
        [Route("/product/AddToOrder/{productId:int}")]
        public ActionResult AddProdToOrder(int productId)
        {
            // get session into
            string sessionString = HttpContext.Session.GetString("CustomerSession");
            if (sessionString != null)
            {
                var sessionCustomer =
                    JsonConvert.DeserializeObject<Customer>(sessionString);

                
                sessionCustomer.AddProdToOrder(productId, sessionCustomer.CustomerID);
                return RedirectToAction("Index", "Order");
                
                
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [Route("/product/RemoveFromOrder/{orderItemId:int}")]
        public ActionResult RemoveProdFromOrder(int orderItemId)
        {
            Customer customer = new Customer();
            customer.RemoveProdFromOrder(orderItemId);
            return RedirectToAction("Index", "Order");
        }



        /*string connectionString = @"Data Source =(LocalDb)\MSSQLLocalDB;Initial Catalog = WebshopDB; Integrated Security = True";
        [HttpGet]
        // GET: ProductController   
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Product";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
            }
                return View(dt);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
