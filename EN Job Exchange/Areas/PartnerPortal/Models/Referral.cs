using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ENJobExchange.Areas.PartnerPortal.Models
{
    public class Referral
    {
        [HiddenInput()]
        public long ReferralID { get; set; }

        [HiddenInput()]
        public long ENID { get; set; }

        [Display(Name = "Employer", Description = "The name of the employer that posted the job")]
        [DisplayFormat(NullDisplayText = "No Employer to display")]
        public string EmployerName { get; set; }

        [HiddenInput(DisplayValue=false)]
        public string EmploymentNetworkName { get; set; }

        [HiddenInput()]
        public long Account_ENID { get; set; }
        
        [HiddenInput()]
        public int ReferralTypeID { get; set; }

        [Display(Name = "Referral Date", Description = "The date the job was posted")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter the date in the correct fomat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}", NullDisplayText = "No Employer Name to display")]
        public DateTime ReferralDate { get; set; }

        [DisplayFormat(NullDisplayText = "Not Available")]
        [Display(Name = "Status", Description = "The status of the current job posting")]
        public string StatusDesc { get; set; }
        
        [StringLength(50, ErrorMessage = "First name must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters into the Name field")]
        [DisplayFormat(NullDisplayText = "Not Available")]
        [Display(Name = "First Name")]
        public string Name_First { get; set; }

        [DisplayFormat(NullDisplayText = "Not Available")]
        [StringLength(50, ErrorMessage = "First name must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters into the Name field")]
        [Display(Name = "Last Name")]
        public string Name_Last { get; set; }

        [DisplayFormat(NullDisplayText = "Not Available")]
        [Display(Name = "EN Notes", Description = "Things to note about the job candidate")]
        public string ENNotes { get; set; }

        [Display(Name = "Requisition Number")]
        [DisplayFormat(NullDisplayText = "Not Available")]
        public string PartnerRequisitionNumber { get; set; }

        [Display(Name = "Job Title")]
        [DisplayFormat(NullDisplayText = "Not Listed")]
        public string JobTitle { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public long JobPostingID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long PartnerID { get; set; }

        [HiddenInput(DisplayValue=false)]
        [ScaffoldColumn(false)]
        public int ReferralStatusID { get; set; }
    }
}