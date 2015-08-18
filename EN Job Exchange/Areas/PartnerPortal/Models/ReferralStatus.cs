using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ENJobExchange.Areas.PartnerPortal.Models
{
    public class ReferralStatus
    {
        [HiddenInput()]
        public int ReferralStatusID { get; set; }
        
        [Display(Name="Status")]
        public string ReferralStatusDesc { get; set; }
    }
}