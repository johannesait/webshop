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
        [Display(Name = "Hind km-ga")]
        [DisplayFormat(DataFormatString = "{0:c}")]
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
        [Display(Name="Hind km-ta")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal PriceWithoutTax { get; set; }

        [Display(Name = "Tootekood")]
        public string ProductCode { get; set; }

        [Display(Name = "Nimetus")]
        public string Title { get; set; }

        [Display(Name = "Nimelisa")]
        public string AdditionalTitle { get; set; }

        [Display(Name = "Ühik")]
        public string Unit { get; set; }

        [Display(Name = "Pakend 1")]
        public Nullable<decimal> Package1 { get; set; }

        [Display(Name = "Pakend 2")]
        public Nullable<decimal> Package2 { get; set; }

        [Display(Name = "Laos")]
        [DisplayFormat(DataFormatString = "{0:F3}")]
        public Nullable<decimal> AmountAvailable { get; set; }

        [Display(Name = "Laos")]
        public Nullable<int> DaysToOrder { get; set; }

        [Display(Name = "Realiseerimistähtaeg")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> ExpiringDate { get; set; }
    }
}
