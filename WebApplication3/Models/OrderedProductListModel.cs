using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class OrderedProductListModel
    {
        public string ProductCode { get; set; }
        public string Title { get; set; }
        public string AdditionalTitle { get; set; }
        public string Unit { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy hh:mm}")]
        public DateTime DateLastOrdered { get; set; }
        public int TimesOrdered { get; set; }
        public string LastOrderNumber { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}