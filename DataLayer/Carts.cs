using DataLayer.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataType(typeof(CartMetaData))]
    public partial class Cart
    {
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPriceWithoutVAT
        {
            get
            {
                decimal totalPrice = 0.00M;
                foreach (var item in CartProducts)
                {
                    totalPrice += item.TotalPriceWithoutVAT;
                }
                return totalPrice;
            }
        }
        [DisplayFormat(DataFormatString="{0:c}")]
        public decimal TotalPriceWithVAT
        {
            get
            {
                return Math.Round(TotalPriceWithoutVAT + (TotalPriceWithoutVAT * Constants.VAT), 2, MidpointRounding.AwayFromZero);
            }
        }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal VATOfTotalPrice
        {
            get
            {
                return TotalPriceWithoutVAT * Constants.VAT;
            }
        }
    }

    public partial class CartMetaData
    {
    }
}
