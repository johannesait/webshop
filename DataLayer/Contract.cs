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
    
    public partial class Contract
    {
        public System.Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string PhoneNr { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string BusinessRegisterNumber { get; set; }
        public string VATPayerNumber { get; set; }
        public Nullable<System.Guid> BusinessFunctionId { get; set; }
        public string ProductCategories { get; set; }
        public string CustomerName { get; set; }
        public string CustomerJobTitle { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryTimes { get; set; }
        public string DeliveryRecipientNames { get; set; }
        public string DeliveryRecipientJobTitles { get; set; }
        public string DeliveryRecipientPhoneNrs { get; set; }
        public bool WantsVisitBySalesperson { get; set; }
        public string PurposeOfSalespersonVisit { get; set; }
        public bool WantsOffersToEmail { get; set; }
    
        public virtual BusinessFunction BusinessFunction { get; set; }
    }
}
