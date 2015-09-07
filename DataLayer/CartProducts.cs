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
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPriceWithoutVAT
        {
            get { return Product != null ? Product.PriceWithoutTax * Amount : 0; }
        }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPriceWithVAT
        {
            get { return Product != null ? Product.PriceWithVAT * Amount : 0; }
        }
    }

    public partial class CartProductMetaData
    {
        [DisplayFormat(DataFormatString = "{0:F3}")]
        public decimal Amount { get; set; }
    }
}
