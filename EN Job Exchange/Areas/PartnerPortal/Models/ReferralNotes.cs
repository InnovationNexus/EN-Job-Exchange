using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ENJobExchange.Areas.PartnerPortal.Models
{
    public class ReferralNotes
    {

        [HiddenInput()]
        public long ReferralNoteID { get; set; }

        [HiddenInput()]
        public long ReferralID { get; set; }

        [HiddenInput()]
        public long Account_EmployerID { get; set; }

        [Display(Name = "Employer Notes", Description = "Notes for employer partners, or to provide as feedback to Employment Networks")]
        public string Note { get; set; }

        [Display(Name = "Provide as feedback")]
        public bool ProvideAsFeedback_YN { get; set; }

        public string Status { get; set; }

    }
}