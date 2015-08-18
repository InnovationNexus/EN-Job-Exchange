using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ENJobExchange.DAL;


namespace ENJobExchange.Areas.ENPortal.ViewModels
{
    public class HomeIndexViewModel
    {
        #region "Private Properties"

        private readonly Repository _rep = new Repository();

        #endregion

        #region "Public Properties"

        public IEnumerable<ENJobExchange.Areas.ENPortal.ViewModels.Referral> Referrals { get; set; }
        public IEnumerable<ENJobExchange.DAL.ReferralNote> ReferralNotes { get; set; }
        public long ENID { get; set; }

        #endregion

        #region "Constructors"

        public HomeIndexViewModel(long ENid)
        {
            ENID = ENid;
            Referrals = _rep.GetENReferrals(ENid);
            ReferralNotes = _rep.GetENReferralNotes(ENid);
        }

        #endregion
    }
}