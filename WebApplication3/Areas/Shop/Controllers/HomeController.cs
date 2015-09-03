using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Areas.Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cert = Request.ClientCertificate;
            return View();
        }
    }
}