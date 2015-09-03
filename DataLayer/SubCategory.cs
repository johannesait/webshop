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
    
    public partial class SubCategory
    {
        public SubCategory()
        {
            this.Products = new HashSet<Product>();
            this.ProductCategoryDiscounts = new HashSet<ProductCategoryDiscount>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.Guid ParentCategoryId { get; set; }
    
        public virtual OrderProduct OrderProduct { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductCategoryDiscount> ProductCategoryDiscounts { get; set; }
    }
}