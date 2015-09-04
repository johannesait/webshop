using DataLayer.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataType(typeof(OrderMetaData))]
    public partial class Cart
    {
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal TotalPriceWithoutVAT
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in CartProducts)
                {
                    totalPrice += item.TotalPriceWithoutVAT;
                }
                return totalPrice;
            }
        }

        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal TotalPriceWithVAT
        {
            get
            {
                return Math.Round(TotalPriceWithoutVAT + (TotalPriceWithoutVAT * Constants.VAT), 2, MidpointRounding.AwayFromZero);
            }
        }

        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal VATOfTotalPrice
        {
            get
            {
                return TotalPriceWithoutVAT * Constants.VAT;
            }
        }
    }

    public partial class OrderMetaData
    {
    }
}
