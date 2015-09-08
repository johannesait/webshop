using DataLayer.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationsExtensions;

namespace DataLayer
{
    [MetadataType(typeof(OrderProductMetaData))]
    public partial class OrderProduct
    {

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal PriceWithVAT
        {
            get { return PriceWithoutTax + (PriceWithoutTax * Constants.VAT); }
        }


        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPriceWithVAT
        {
            get { return PriceWithVAT * Amount; }
        }


        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPriceWithoutVAT
        {
            get { return PriceWithoutTax * Amount; }
        }
    }

    public partial class OrderProductMetaData
    {
        [DisplayFormat(DataFormatString = "{0:F3}")]
        [Min(0.001)]
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal PriceWithoutTax { get; set; }
    }
}
