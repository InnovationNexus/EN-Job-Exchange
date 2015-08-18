using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ENJobExchange.Areas.PartnerPortal.Models
{
    public class JobPosting
    {
        [HiddenInput()]
        public long JobPostingID { get; set; }

        [HiddenInput()]
        public long PartnerID { get; set; }

        [Display(Name = "Location ID Number")]
        public Nullable<long> LocationID { get; set; }

        [HiddenInput()]
        public long PositionID { get; set; }

        [Display(Name = "Contact ID Number")]
        public Nullable<long> ContactID { get; set; }

        [Display(Name = "Partner Requisistion Number")]
        [DisplayFormat(NullDisplayText = "No Partner Requisistion Number to display")]
        public string PartnerRequisitionNumber { get; set; }

        [DisplayFormat(NullDisplayText = "No Partner Job Level to display")]
        [Display(Name = "Partner Job Level", Description = "??")]
        public string PartnerJobLevel { get; set; }

        [Required()]
        [Display(Name = "Job Title")]
        [DisplayFormat(NullDisplayText = "No Job Title to display")]
        [StringLength(50, ErrorMessage = "Job title must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "Job title must be longer than 2 characters")]
        public string JobTitle { get; set; }

        [Display(Name = "Business Category")]
        [DisplayFormat(NullDisplayText = "No Business Category to display")]
        [StringLength(50, ErrorMessage = "Business Category must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "Business Category must be longer than 2 characters")]
        public string BusinessCategory { get; set; }


        [Display(Name = "Job Posting Description")]
        [DisplayFormat(NullDisplayText = "No Job Positing Description to display")]
        [StringLength(2000, ErrorMessage = "Job title must be shorter than 50 characters")]
        [Required(ErrorMessage = "Description is required")]
        public string Description_JobPosting { get; set; }

        [Display(Name = "Description")]
        [DisplayFormat(NullDisplayText = "--")]
        [Required(ErrorMessage = "Description is required")]
        public string Description_External { get; set; }

        [DisplayFormat(NullDisplayText = "No Job Requirements to display")]
        [Display(Name = "Job Requirements")]
        public string Requirements { get; set; }

        [DisplayFormat(NullDisplayText = "No Estimated Weekly Hours to display")]
        [Display(Name = "Estimated Weekly Hours")]
        public string EstHoursPerWeek { get; set; }

        [DisplayFormat(NullDisplayText = "No Schedule to display")]
        [Display(Name = "Schedule")]
        public string WorkSchedule { get; set; }

        [Required()]
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}", NullDisplayText = "No Created Date to display")]
        public System.DateTime CreatedDT { get; set; }

        [Required()]
        [Display(Name = "Posting Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}", NullDisplayText = "No Posting Start Date to display")]
        public System.DateTime PostingStartDate { get; set; }

        //should we require this?
        [Display(Name = "Posting End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}", NullDisplayText = "No Posting End Date to display")]
        public Nullable<System.DateTime> PostingEndDate { get; set; }

        [Display(Name = "Active Status")]
        public bool Active_YN { get; set; }

    }
}