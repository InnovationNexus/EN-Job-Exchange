using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ENJobExchange.Models
{
    public class EmpJobPosting
    {
        [ScaffoldColumn(false)]
        public long JobPostingID { get; set; }
        
        [ScaffoldColumn(false)]
        public long PartnerID { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<long> LocationID { get; set; }

        [ScaffoldColumn(false)]
        public long PositionID { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<long> ContactID { get; set; }
        
        [Display(Name="Job Requisistion Number")]
        public string PartnerRequisitionNumber { get; set; }
        
        [Display(Name="Partner Job Level", Description="??")]
        public string PartnerJobLevel { get; set; }
        
        [Required()]
        [Display(Name="Job Title")]
        [StringLength(50, ErrorMessage="Job title must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage="Job title must be longer than 2 characters")]
        public string JobTitle { get; set; }

        [Required()]
        [Display(Name = "Business Category")]
        [StringLength(50, ErrorMessage = "Business Category must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "Business Category must be longer than 2 characters")]
        public string BusinessCategory { get; set; }
     
        //public string Description_External { get; set; }

        [Required()]
        [Display(Name = "Job Posting Description")]
        [StringLength(2000, ErrorMessage = "Job title must be shorter than 50 characters")]
        public string Description_JobPosting { get; set; }

        [Required()]
        [Display(Name = "Job Requirements")]
        public string Requirements { get; set; }

        [Required()]
        [Display(Name = "Estimated Weekly Hours")]
        public string EstHoursPerWeek { get; set; }

        [Required()]
        [Display(Name = "Schedule")]
        public string WorkSchedule { get; set; }

        [Required()]
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:d}")]
        public System.DateTime CreatedDT { get; set; }

        [Required()]
        [Display(Name = "Posting Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public System.DateTime PostingStartDate { get; set; }

        //should we require this?
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> PostingEndDate { get; set; }

        [Display(Name = "Active Status")]
        public bool Active_YN { get; set; }
    }
}