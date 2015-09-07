using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DataLayer;

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
    }
}