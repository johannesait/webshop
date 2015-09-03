using DataLayer;
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

        private Cart getUserShoppingCart() {
            Cart cart = null;
            //mis siis kui mitu kasutajat samas arvutis on?
            //peab ikka siduma kasutajaga, kui on sisse logitud
            var cookie = Request.Cookies["cartId"];
            if (cookie == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    CartProducts = new List<CartProduct>()
                };
                Context.Carts.Add(cart);
                Context.SaveChangesAsync();
                cookie = new HttpCookie("cartId", cart.Id.ToString());
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.SetCookie(cookie);
            }
            else
            {
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
    }
}