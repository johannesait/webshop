using DataLayer.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataType(typeof(OrderProductMetaData))]
    public partial class OrderProduct
    {

        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal PriceWithVAT
        {
            get { return PriceWithoutTax + (PriceWithoutTax * Constants.VAT); }
        }


        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal TotalPriceWithVAT
        {
            get { return PriceWithVAT * Amount; }
        }


        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal TotalPriceWithoutVAT
        {
            get { return PriceWithoutTax * Amount; }
        }
    }

    public partial class OrderProductMetaData
    {
        [DisplayFormat(DataFormatString = "{0:#.##}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
    }
}
