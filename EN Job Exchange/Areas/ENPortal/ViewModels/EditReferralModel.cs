using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ENJobExchange.DAL;
using System.Web.Mvc;


namespace ENJobExchange.Areas.ENPortal.ViewModels
{
    public class EditReferralModel
    {
        #region "Public Properties"

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long ReferralID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public System.DateTime Referral_DT { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long JobPostingID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public int ReferralTypeID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public int ReferralStatusID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long Account_ENID { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public long ENID { get; set; }

        [StringLength(50, ErrorMessage = "First name must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters into the Name field")]
        [Display(Name = "First Name")]
        public string Name_First { get; set; }

        [StringLength(50, ErrorMessage = "First name must be shorter than 50 characters")]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters into the Name field")]
        [Display(Name = "Last Name")]
        public string Name_Last { get; set; }

        [Display(Name = "Uploaded Cover Letter")]
        public string File_CoverLetter { get; set; }

        [Display(Name = "Uploaded Resume")]
        public string File_Resume { get; set; }

        [Display(Name = "EN Notes")]
        public string EN_Notes { get; set; }

        #endregion

        #region "Constructors"

        public EditReferralModel()
        {
        }

        #endregion
    }
}