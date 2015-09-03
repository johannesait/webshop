﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        private readonly MonesJaTuurPoodEntities Context = new MonesJaTuurPoodEntities();

        public ActionResult Cart()
        {
            var cart = getUserShoppingCart();
            return PartialView(cart);
        }

        public JsonResult CartTotalSum()
        {
            var cart = getUserShoppingCart();

            return Json(new { totalSum = cart.TotalPriceWithVAT }, JsonRequestBehavior.AllowGet);
        }

        private Cart newCart()
        {
            //if kasutaja on sisse loginud, siis seo kasutajaga
            return new Cart
            {
                Id = Guid.NewGuid(),
                CartProducts = new List<CartProduct>()
            };
        }

        private Cart getUserShoppingCart() {
            Cart cart = null;
            //mis siis kui mitu kasutajat samas arvutis on?
            //peab ikka siduma kasutajaga, kui on sisse logitud
            var cookie = Request.Cookies["cartId"];
            if (cookie == null)
            {
                cart = newCart();
                Context.Carts.Add(cart);
                Context.SaveChanges();
                cookie = new HttpCookie("cartId", cart.Id.ToString());
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.SetCookie(cookie);
            }
            else
            {
                //if cookie is expired create a new cart and cookie
                //if (cookie.Expires < DateTime.Now)
                //{
                //    var oldCart = Context.Carts.Find(Guid.Parse(cookie.Value));
                //    Context.Carts.Remove(oldCart);
                //    Context.SaveChanges();

                //    cart = newCart();
                //    cookie.Value = cart.Id.ToString();
                //    cookie.Expires = DateTime.Now.AddDays(1);
                //    Response.SetCookie(cookie);
                //}
                //else
                //{
                //    Guid cartId = Guid.Parse(cookie.Value);
                //    cart = Context.Carts.Find(cartId);
                //}
                Guid cartId = Guid.Parse(cookie.Value);
                cart = Context.Carts.Find(cartId);
                
            }

            return cart;
        }

        public JsonResult AddProductToCart(Guid id, decimal amount)
        {
            try
            {
                var cart = getUserShoppingCart();
                var product = Context.Products.Find(id);

                var existingCartProduct = cart.CartProducts.SingleOrDefault(x => x.ProductId == product.ProductId);

                if (existingCartProduct != null)
                {
                    existingCartProduct.Amount += amount;
                }
                else
                {
                    cart.CartProducts.Add(new CartProduct
                    {
                        Cart = cart,
                        Product = product,
                        Amount = amount
                    });
                }

                Context.SaveChangesAsync();

                return Json(new {success = true});
            }
            catch (Exception e)
            {
                return Json(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        public JsonResult RemoveProductFromCart(Guid id)
        {
            try
            {
                var cart = getUserShoppingCart();
                var removedProduct = cart.CartProducts.SingleOrDefault(x => x.ProductId == id);
                if (removedProduct != null)
                    cart.CartProducts.Remove(removedProduct);
                Context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false, errorMessage = e.Message });
            }
        }

        public ActionResult CategoryMenu()
        {
            var categories = Context.ProductCategories;
            return PartialView(categories);
        }

        public ActionResult ProductList(string categoryName)
        {
            ViewBag.Title = categoryName;
            var productCategory = Context.SubCategories.SingleOrDefault(x => x.Name == categoryName);
            var products = productCategory.Products;
            return PartialView(products);
        }

        public ActionResult CartConfirmation()
        {
            var user = new AspNetUser(){
                UserName = "sandra62",
                Email = "sandra.demitseva@gmail.com",
                Id = Guid.NewGuid().ToString()
            };
            var cart = getUserShoppingCart();

            var order = new Order() { 
                Id = cart.Id,
                UserId = user.Id,
                OrderNumber = "100"
            };
            order.OrderStatu = Context.OrderStatus.Single(x => x.Status == "Maksmata");
            foreach (var item in cart.CartProducts)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    Id = Guid.NewGuid(),
                    ProductCode = item.Product.ProductCode,
                    Title = item.Product.Title,
                    AdditionalTitle = item.Product.AdditionalTitle,
                    Unit = item.Product.Unit,
                    PriceWithoutTax = item.Product.PriceWithoutTax,
                    SubCategoryId = item.Product.SubCategoryId,
                    Amount = item.Amount,
                    OrderId = order.Id
                });
            }

            Context.Carts.Remove(cart);
            var cookie = Request.Cookies["cartId"];
            if (cookie != null)
            {
                cookie.Value = null;
                Response.SetCookie(cookie);
            }
            Context.AspNetUsers.Add(user);
            Context.Orders.Add(order);
            Context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }
    }
}