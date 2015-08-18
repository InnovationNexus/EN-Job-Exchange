using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENJobExchange.DAL;
using System.Web.Mvc;

namespace ENJobExchange.Areas.ENPortal.ViewModels
{
    public class ReferralHistory
    {
        #region "Private Properties"
        private Entities db = new Entities();
        private Repository _rep = new Repository();
        #endregion

        #region "Public Properties"
        public Int64 ENID { get; set; }
        public SelectList ReferralStatusList { get; set; }
        public IEnumerable<ENPortal.ViewModels.Referral> Referrals { get; set; }
        public short SelectedReferralStatusID { get; set; }
        public short CreatedLastX { get; set; }
        #endregion

        //constructors
        public ReferralHistory(Int64 id)
        {
            this.ENID = id;
            this.SelectedReferralStatusID = -1;
            this.CreatedLastX = 360;
            SelectListItem itm1 = new SelectListItem() { Text = "[All Referrals]", Value = "-1" };
            SelectListItem itm2 = new SelectListItem() { Text = "[Active Referrals]", Value = "100" };
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(itm1);
            items.Add(itm2);
            items.AddRange((from d in db.ReferralStatus orderby d.ReferralStatusID select d).AsEnumerable().Select(r => new SelectListItem() { Text = r.ReferralStatusDesc, Value = r.ReferralStatusID.ToString() }));
            this.ReferralStatusList = new SelectList(items, "Value", "Text", -1);

            //this.ReferralStatusList = (SelectList)this.ReferralStatusList.Concat(from d in db.ReferralStatus orderby d.ReferralStatusID select new SelectListItem() { Text = d.ReferralStatusDesc, Value = d.ReferralStatusID.ToString() });
            //--- Get all referral records for ENID by default
            this.Referrals = _rep.GetENReferrals(this.ENID, -1, this.CreatedLastX);
        }

        public ReferralHistory(Int64 id, Int16 referralStatusID, Int16 createdLastXDays)
        {
            this.ENID = id;
            this.SelectedReferralStatusID = referralStatusID;
            SelectListItem itm1 = new SelectListItem() { Text = "[All Referrals]", Value = "-1" };
            SelectListItem itm2 = new SelectListItem() { Text = "[Active Referrals]", Value = "100" };
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(itm1);
            items.Add(itm2);
            items.AddRange((from d in db.ReferralStatus orderby d.ReferralStatusID select d).AsEnumerable().Select(r => new SelectListItem() { Text = r.ReferralStatusDesc, Value = r.ReferralStatusID.ToString() }));
            this.ReferralStatusList = new SelectList(items, "Value", "Text", this.SelectedReferralStatusID);

            //this.ReferralStatusList = new SelectList((from d in db.ReferralStatus orderby d.ReferralStatusID select new SelectListItem() { Text = d.ReferralStatusDesc, Value = d.ReferralStatusID.ToString() }), referralStatusID);
            this.CreatedLastX = createdLastXDays;
            //--- Get all referral records for ENID by default
            this.Referrals = _rep.GetENReferrals(this.ENID, (short)this.ReferralStatusList.SelectedValue, this.CreatedLastX);
        }

        
        //public methods
        public void UpdateList()
        {
            this.Referrals = _rep.GetENReferrals(this.ENID, (Int16) this.ReferralStatusList.SelectedValue, this.CreatedLastX);
        }
        


    } //--- end class
} //--- end namespace