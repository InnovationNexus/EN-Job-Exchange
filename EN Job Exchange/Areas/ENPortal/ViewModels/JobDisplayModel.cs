using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ENJobExchange.DAL;
using System.Data.Entity;
using System.Web.Mvc;

namespace ENJobExchange.Areas.ENPortal.ViewModels
{
    public class JobDisplayModel
    {
        #region "Private Properties"

        private Entities db = new Entities();
        private Repository _rep = new Repository();
        private JobPosting jp1; 

        #endregion

        #region "Public Properties"

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long JobPostingID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public string BusinessCategory { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public string Description_External { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public string Description_JobPosting { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Requirements")]
        [DisplayFormat(NullDisplayText = "Not Listed")]
        public string Requirements { get; set; }

        [Display(Name = "Estimated Hours per Week")]
        [DisplayFormat(NullDisplayText = "Not Listed")]
        public string EstHoursPerWeek { get; set; }

        [Display(Name = "Work Schedule")]
        [DisplayFormat(NullDisplayText = "Not Listed")]
        public string WorkSchedule { get; set; }

        [Display(Name = "Job Posting Creation Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter the date in the correct fomat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public System.DateTime CreatedDT { get; set; }

        [Display(Name = "Job Available Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter the date in the correct fomat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public System.DateTime PostingStartDate { get; set; }

        [Display(Name = "Job Posting Expiration Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter the date in the correct fomat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}", NullDisplayText = "No Job Expiration Date to display")]
        public Nullable<System.DateTime> PostingEndDate { get; set; }

        [Display(Name = "Active Y/N")]
        public bool Active_YN { get; set; }

        [Display(Name="Company Name")]
        [DisplayFormat(NullDisplayText = "Not Available")]
        public string CompanyName { get; set; }

        [Display(Name="Location")]
        [DisplayFormat(NullDisplayText = "Not Listed")]
        public string CityStateZip { get; set; }

        #endregion

        public JobDisplayModel()
        {
        }

        public JobDisplayModel(long JobPostingID)
        {
         
            if (JobPostingID > 0)
            {
                jp1 = _rep.getJobPostingByID(JobPostingID);
                this.JobPostingID = JobPostingID;
                this.JobTitle = jp1.JobTitle;
                this.BusinessCategory = jp1.BusinessCategory;
                this.Description_External = jp1.Description_External;
                this.Description_JobPosting = jp1.Description_JobPosting;
                this.Requirements = jp1.Requirements;
                this.EstHoursPerWeek = jp1.EstHoursPerWeek;
                this.WorkSchedule = jp1.WorkSchedule;
                this.CreatedDT = jp1.CreatedDT;
                this.PostingStartDate = jp1.PostingStartDate;
                this.PostingEndDate = jp1.PostingEndDate;
                this.Active_YN = jp1.Active_YN;
                this.CompanyName = _rep.GetEmployerName_ForPartnerID(jp1.PartnerID);
                this.CityStateZip = _rep.GetCityStateZip_ForJobPostingID(JobPostingID);
            }


        }

    }
}