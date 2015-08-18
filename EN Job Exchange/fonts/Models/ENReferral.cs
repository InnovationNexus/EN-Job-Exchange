using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ENJobExchange.DAL;

//NOT FINISHED

namespace ENJobExchange.Areas.ENPortal.Models
{
    public class Referral
    {
        Entities db = new Entities();

        [ScaffoldColumn(false)]
        [Display(Name = "DO NOT DISPLAY -- ENID")]
        public long ENID { get; set; }

        [Display(Name = "Employer", Description = "The name of the employer that posted the job")]
        public string EmployerName { get; set; }

        [Display(Name = "Employment Network", Description = "The name of the employment network ???")]
        public string EmploymentNetworkName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "DO NOT DISPLAY -- Account_ENID")]
        public long Account_ENID { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Do we want to display this?", Description = "The name of the employer that posted the job")]
        public int ReferralTypeID { get; set; }

        [Display(Name = "Referral Date", Description = "The date the job was posted")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter the date in the correct fomat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ReferralDate { get; set; }

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

        [Display(Name = "Are we going to display this?", Description = "The name of the employer that posted the job")]
        public string ENNotes { get; set; }

        [Display(Name = "Employer Name", Description = "The name of the employer that posted the job")]
        public long EmpID { get; set; }

        public long ReferralID { get; set; }

        //--- Constructor
        public Referral()
        {
            this.ReferralID = 0;
        }

        public bool SaveToDB()
        {
            //... Finish coding property assignments.
            var ttst = new ENJobExchange.DAL.Referral() { EN_Notes = ENNotes, ENID = this.ENID, Name_First = this.Name_First, Name_Last = this.Name_Last  };

            try
            {
                if (this.ReferralID == 0)
                {
                    db.Referrals.Add(ttst);
                    db.SaveChanges();
                    //... Get new ReferralID and set this.ReferralID
                    
                    return true;
                }
                else
                {
                    //... code to update existing Referral record.
                    return true;
                }
            }
            catch { return false; }

        }
    }
}