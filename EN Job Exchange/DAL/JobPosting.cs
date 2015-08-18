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
    
    public partial class JobPosting
    {
        public JobPosting()
        {
            this.tblFlaggedPostings = new HashSet<FlaggedPosting>();
            this.tblReferrals = new HashSet<Referral>();
        }
    
        public long JobPostingID { get; set; }
        public long PartnerID { get; set; }
        public Nullable<long> LocationID { get; set; }
        public long PositionID { get; set; }
        public Nullable<long> ContactID { get; set; }
        public string PartnerRequisitionNumber { get; set; }
        public string PartnerJobLevel { get; set; }
        public string JobTitle { get; set; }
        public string BusinessCategory { get; set; }
        public string Description_External { get; set; }
        public string Description_JobPosting { get; set; }
        public string Requirements { get; set; }
        public string EstHoursPerWeek { get; set; }
        public string WorkSchedule { get; set; }
        public System.DateTime CreatedDT { get; set; }
        public System.DateTime PostingStartDate { get; set; }
        public Nullable<System.DateTime> PostingEndDate { get; set; }
        public bool Active_YN { get; set; }
    
        public virtual ICollection<FlaggedPosting> tblFlaggedPostings { get; set; }
        public virtual Partner tblPartner { get; set; }
        public virtual Position tblPosition { get; set; }
        public virtual ICollection<Referral> tblReferrals { get; set; }
        public virtual Location tblLocation { get; set; }
    }
}