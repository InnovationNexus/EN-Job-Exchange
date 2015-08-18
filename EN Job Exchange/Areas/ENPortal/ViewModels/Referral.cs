using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ENJobExchange.DAL;
using System.Web.Mvc;

//NOT FINISHED

namespace ENJobExchange.Areas.ENPortal.ViewModels
{
    public class Referral
    {

        #region "Private Properties"

        private Entities db = new Entities();
        private Repository _rep = new Repository();
        private long id = 0;

        #endregion

        #region "Public Properties"

        public IEnumerable<ReferralType> ReferralTypes { get; set; }
        public JobPosting PostedJob { get; set; }
        public IEnumerable<ENJobExchange.DAL.ReferralNote> ReferralNotes { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long ReferralID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long JobPostingID { get; set; }
        
        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long ENID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue=false)]
        [Display(Name = "EN Name", Description = "The name of the employment network provider")]
        public string EN_Name { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Employer ID", Description = "The ID of the employer that posted the job")]
        public long EmpID { get; set; }

        [Display(Name = "Employer", Description = "The name of the employer that posted the job")]
        public string EmployerName { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Employment Network", Description = "The name of the employment network ???")]
        public string EmploymentNetworkName { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Account_ENID", Description = "Account ENID")]
        public long Account_ENID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Referral Type ID", Description = "The type of referral")]
        public int ReferralTypeID { get; set; }

        [Display(Name = "Referral Type", Description = "The type of referral")]
        public String ReferralTypeDescription { get; set; }
        
        [Display(Name = "Referral Date", Description = "The date the job was posted")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter the date in the correct fomat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Referral_DT { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public int ReferralStatusID { get; set; }

        [Display(Name = "Status", Description = "The status of the current job posting")]
        public string StatusDesc { get; set; }

        [StringLength(50, ErrorMessage = "First name must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters into the Name field")]
        [Display(Name = "First Name")]
        public string Name_First { get; set; }

        [StringLength(50, ErrorMessage = "First name must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters into the Name field")]
        [Display(Name = "Last Name")]
        public string Name_Last { get; set; }

        [Display(Name = "EN Notes", Description = "Notes from the EN")]
        [DisplayFormat(NullDisplayText = "No EN Notes to display")]
        public string EN_Notes { get; set; }

        [Display(Name = "Cover Letter", Description = "The Cover Letter on file")]
        [DisplayFormat(NullDisplayText = "No Cover Letter to display")]
        public string File_CoverLetter { get; set; }

        [Display(Name = "Resume", Description = "Name of the Resume on file")]
        [DisplayFormat(NullDisplayText = "No Resume to display")]
        public string File_Resume { get; set; }
        
        [Display(Name="Confirmation Number")]
        [DisplayFormat(NullDisplayText = "No Confirmation Number to display")]
        public string ConfirmationNumber { get; set; }

        [Display(Name = "Position")]
        [DisplayFormat(NullDisplayText = "Not Available")]
        public string JobTitle { get; set; }

        #endregion



        public Referral()
        {
        
        }

 
        public bool SaveToDB()
        {
            //... Finish coding property assignments.
            var ttst = new ENJobExchange.DAL.Referral()
            {

                Referral_DT = System.DateTime.Now,
                JobPostingID = this.JobPostingID,
                Account_ENID = 2,
                ENID = 3,
                Name_First = this.Name_First,
                Name_Last = this.Name_Last,
                ReferralTypeID = 1,
                ReferralStatusID = 1,
                EN_Notes = this.EN_Notes,
                File_CoverLetter = "",
                File_Resume = "",
                ConfirmationNumber = this.ConfirmationNumber
            };
            try
            {
                if (this.ReferralID == 0)
                {
                    db.Referrals.Add(ttst);
                    db.SaveChanges();
                    this.ReferralID = ttst.ReferralID;
                    //... Get new ReferralID and set this.ReferralID
                    return true;
                }
                else
                {

                    //... code to update existing Referral record.
                    return true;
                }
            }
            catch (Exception ex1) {
                
                return false; }

        }
    }
}