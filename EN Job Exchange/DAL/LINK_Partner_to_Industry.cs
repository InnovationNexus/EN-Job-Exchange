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
    
    public partial class LINK_Partner_to_Industry
    {
        public long Partner_to_IndustryID { get; set; }
        public long PartnerID { get; set; }
        public long IndustryID { get; set; }
    
        public virtual Industry tblLIST_Industry { get; set; }
        public virtual Partner tblPartner { get; set; }
    }
}
