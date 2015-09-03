using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataType(typeof(CartProductMetaData))]
    public partial class CartProduct
    {
        [DisplayFormat(DataFormatString = "{0:#.##}", ApplyFormatInEditMode = true)]
        public decimal TotalPriceWithoutVAT {
            get { return Product.PriceWithoutTax * Amount; }
        }

        [DisplayFormat(DataFormatString = "{0:#.##}", ApplyFormatInEditMode = true)]
        public decimal TotalPriceWithVAT
        {
            get { return Product.PriceWithVAT * Amount; }
        }
    }

    public partial class CartProductMetaData
    {
        [DisplayFormat(DataFormatString = "{0:#.##}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
    }
}
