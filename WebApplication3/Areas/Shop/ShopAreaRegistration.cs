using System.Web.Mvc;

namespace WebApplication3.Areas.Shop
{
    public class ShopAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Shop";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Shop_default",
                "Shop/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "WebApplication3.Areas.Shop.Controllers" }
            );
        }
    }
}