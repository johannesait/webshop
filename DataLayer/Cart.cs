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
    
    public partial class Cart
    {
        public Cart()
        {
            this.CartProducts = new HashSet<CartProduct>();
        }
    
        public System.Guid Id { get; set; }
        public string UserId { get; set; }
    
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
