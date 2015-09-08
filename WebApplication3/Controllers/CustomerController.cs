using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MonesJaTuurPoodEntities Context = new MonesJaTuurPoodEntities();

        // GET: Customer
        public ActionResult CreateContract()
        {
            ViewBag.BusinessFunctions = Context.BusinessFunctions.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });

            var yesNoSelectItems = new List<SelectListItem>();
            yesNoSelectItems.Add(new SelectListItem
            {
                Value = "true",
                Text = "Jah"
            });
            yesNoSelectItems.Add(new SelectListItem
            {
                Value = "false",
                Text = "Ei"
            });
            ViewBag.YesNoSelectItems = yesNoSelectItems;

            if (Request.IsAjaxRequest())
                return PartialView();
            else
                return View();
        }

        [HttpPost]
        public ActionResult CreateContract(Contract contract)
        {
            contract.Id = Guid.NewGuid();
            Context.Contracts.Add(contract);
            Context.SaveChanges();
            return View();
        }
    }
}