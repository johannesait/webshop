using DataLayer.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataType(typeof(ContractMetaData))]
    public partial class Contract
    {
    }

    public partial class ContractMetaData
    {
        [Display(Name="Firma nimi")]
        public string CompanyName { get; set; }

        [Display(Name = "Firma juriidiline aadress")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNr { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Display(Name = "Ärireg. nr")]
        public string BusinessRegisterNumber { get; set; }

        [Display(Name = "Käibemaksukohuslase nr")]
        public string VATPayerNumber { get; set; }

        [Display(Name = "Määratle firma äritähised")]
        public Nullable<System.Guid> BusinessFunctionId { get; set; }

        [Display(Name = "Millised kaubagrupid teid huvitavad")]
        public string ProductCategories { get; set; }

        [Display(Name = "Kauba tellija isiku nimi")]
        public string CustomerName { get; set; }

        [Display(Name = "Kauba tellija ametinimetus")]
        public string CustomerJobTitle { get; set; }

        [Display(Name = "Kauba tellija isiku kontakttelefon")]
        public string CustomerPhoneNumber { get; set; }

        [Display(Name = "Kauba tellija isiku e-post")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Kaup toimetada aadressile")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Soovitavad kauba üleandmise ajad")]
        public string DeliveryTimes { get; set; }

        [Display(Name = "Kauba vastuvõtja nimi (nimed)")]
        public string DeliveryRecipientNames { get; set; }

        [Display(Name = "Kauba vastuvõtja ametinimetus(ed)")]
        public string DeliveryRecipientJobTitles { get; set; }

        [Display(Name = "Kauba vastuvõtja kontakttelefon(id)")]
        public string DeliveryRecipientPhoneNrs { get; set; }

        [Display(Name = "Kas soovite meie müügijuhi külastust ja millisel eesmärgil")]
        public Nullable<bool> WantsVisitBySalesperson { get; set; }

        [Display(Name = "Millisel eesmärgil")]
        public string PurposeOfSalespersonVisit { get; set; }

        [Display(Name = "Kas soovite pakkumisi ja muud infot oma meiliaadressile")]
        public Nullable<bool> WantsOffersToEmail { get; set; }
    }
}
