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
    
    public partial class CartProduct
    {
        public System.Guid CartId { get; set; }
        public System.Guid ProductId { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}