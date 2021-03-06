//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.CartProducts = new HashSet<CartProduct>();
            this.ProductDiscounts = new HashSet<ProductDiscount>();
            this.ViewedProducts = new HashSet<ViewedProduct>();
        }
    
        public System.Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Title { get; set; }
        public string AdditionalTitle { get; set; }
        public string Unit { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public Nullable<decimal> DiscountPriceWithoutTax { get; set; }
        public System.Guid SubCategoryId { get; set; }
        public System.Guid PhotoId { get; set; }
        public decimal Package1 { get; set; }
        public Nullable<decimal> Package2 { get; set; }
        public decimal AmountAvailable { get; set; }
        public Nullable<int> DaysToOrder { get; set; }
        public Nullable<System.DateTime> ExpiringDate { get; set; }
        public Nullable<System.Guid> PackageId { get; set; }
    
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual Package Package { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ProductPhoto ProductPhoto { get; set; }
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
        public virtual ICollection<ViewedProduct> ViewedProducts { get; set; }
    }
}
