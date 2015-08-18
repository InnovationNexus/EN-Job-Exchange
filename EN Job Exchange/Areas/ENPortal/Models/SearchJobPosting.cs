using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENJobExchange.Areas.ENPortal.Models
{
    public class SearchJobPosting
    {

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

    }
}