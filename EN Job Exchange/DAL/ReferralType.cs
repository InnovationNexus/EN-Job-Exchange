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
    
    public partial class ReferralType
    {
        public ReferralType()
        {
            this.tblReferrals = new HashSet<Referral>();
        }
    
        public int ReferralTypeID { get; set; }
        public string ReferralTypeName { get; set; }
    
        public virtual ICollection<Referral> tblReferrals { get; set; }
    }
}