//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENJobExchange.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public long ContactID { get; set; }
        public long PartnerID { get; set; }
        public Nullable<long> LocationID { get; set; }
        public string ContactName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Phone_Work1 { get; set; }
        public string Phone_Work2 { get; set; }
        public string Phone_Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool IsPrimaryContact_YN { get; set; }
    
        public virtual Partner tblPartner { get; set; }
    }
}
