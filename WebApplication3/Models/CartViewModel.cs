using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CartViewModel
    {
        public IEnumerable<Product> Products { get; set; }

    }
}