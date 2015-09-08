using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DataLayer;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    public class OrderController : Controller
    {
        private readonly MonesJaTuurPoodEntities Context = new MonesJaTuurPoodEntities();
        // GET: Order
        public ActionResult Index(bool? wasRedirected)
        {
            if (wasRedirected == true) {
                ViewBag.ShowOrderSuccess = true;
                Response.AppendHeader("X-WiseLinks-Url", Url.Action("Index", "Order"));
            }

            var userId = User.Identity.GetUserId();
            var userOrders = Context.AspNetUsers.Find(userId).Orders.OrderByDescending(x => x.DateOfOrder);

            return View(userOrders);
        }

        public ActionResult Details(Guid id)
        {
            var orderDetails = Context.Orders.Find(id);
            return View(orderDetails);
        }

        public ActionResult OrderedProducts()
        {
            var userId = User.Identity.GetUserId();
            var userOrders = Context.AspNetUsers.Find(userId).Orders;

            var productList = new List<OrderedProductListModel>();
            foreach (var order in userOrders)
            {
                for (int i = 0; i < order.OrderProducts.Count; i++)
                {
                    var orderProduct = order.OrderProducts.ElementAt(i);
                    var oldOrders = userOrders.SelectMany(x => x.OrderProducts.Where(y => y.ProductCode == orderProduct.ProductCode)).OrderByDescending(y => y.Order.DateOfOrder);

                    var orderedProduct = new OrderedProductListModel
                    {
                        ProductCode = orderProduct.ProductCode,
                        Title = orderProduct.Title,
                        AdditionalTitle = orderProduct.AdditionalTitle,
                        Unit = orderProduct.Unit,
                        DateLastOrdered = oldOrders.Select(z => z.Order.DateOfOrder).First(),
                        LastOrderNumber = oldOrders.Select(z => z.Order.OrderNumber).First(),
                        TimesOrdered = oldOrders.Count(),
                        OrderId = oldOrders.Select(z=>z.Order.Id).First(),
                        ProductId = Context.Products.Single(y => y.ProductCode == orderProduct.ProductCode).ProductId
                    };
                    productList.Add(orderedProduct);
                }
            }
            var list = productList.GroupBy(x => x.ProductCode).Select(y => y.First());
            return View(list);
        }
    }
}