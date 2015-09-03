using DataLayer.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        [DisplayFormat(DataFormatString = "{0:#.##}", ApplyFormatInEditMode = true)]
        public decimal PriceWithVAT
        {
            get
            {
                return PriceWithoutTax + (PriceWithoutTax * Constants.VAT);
            }
        }
    }

    public partial class ProductMetaData
    {
        [DisplayFormat(DataFormatString = "{0:#.##}", ApplyFormatInEditMode = true)]
        public decimal PriceWithoutTax { get; set; }
    }
}
