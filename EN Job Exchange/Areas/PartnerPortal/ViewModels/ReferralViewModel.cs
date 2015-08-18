using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENJobExchange.Areas.PartnerPortal.Models;
using System.Web.Mvc;
using System.Data.Entity.SqlServer;

namespace ENJobExchange.Areas.PartnerPortal.ViewModels
{
    public class ReferralViewModel
    {
        public long Account_EmployerID { get; set; }
        public long ReferralID { get; set; }
        public Referral referral { get; set; }
        public IEnumerable<ReferralNotes> ReferralNotes { get; set; }
        public ReferralStatus ReferralStatus { get; set; }
        public ENJobExchange.DAL.Entities db;
        public int Status { get; set; }


        public ReferralViewModel(long referralID)
        {
            db = new ENJobExchange.DAL.Entities();
            ReferralID = referralID;
            referral = getOneReferralsByReferralID();
            ReferralNotes = getReferralNotesByReferralID();
            Account_EmployerID = 2; //CHANGE ME LATER
            Status = getReferralStatusIDByReferralID();
        }

        //This is a great example DropDownList
        public SelectList GetStatusList()
        {
            SelectList list = new SelectList (db.ReferralStatus, "ReferralStatusID", "ReferralStatusDesc", this.Status);
            return list;
        }

        private int getReferralStatusIDByReferralID()
        {
            int status = (from s in db.ReferralStatus
                            join r in db.Referrals on s.ReferralStatusID equals r.ReferralStatusID
                            where r.ReferralID == ReferralID
                            select s.ReferralStatusID).Single();
                return status;
        }

        private Referral getOneReferralsByReferralID()
        {
            Referral list =
                (from r in db.Referrals
                 where r.ReferralID == ReferralID
                 select new Referral { Account_ENID = r.Account_ENID, PartnerID = r.tblJobPosting.PartnerID, ReferralID = r.ReferralID, ENNotes = r.EN_Notes, ReferralTypeID = r.ReferralTypeID, ENID = r.ENID, EmployerName = r.tblJobPosting.tblPartner.CompanyName, EmploymentNetworkName = r.tblEN.Name, StatusDesc = r.tblLIST_ReferralStatus.ReferralStatusDesc, ReferralDate = r.Referral_DT, Name_First = r.Name_First, Name_Last = r.Name_Last }).Single();
            return list;
        }

        private IEnumerable<ReferralNotes> getReferralNotesByReferralID()
        {
            IEnumerable<ReferralNotes> list =
                (from rn in db.ReferralNotes
                 where rn.ReferralID == ReferralID
                 select new ReferralNotes { Account_EmployerID = rn.Account_EmployerID, Note = rn.Note, ProvideAsFeedback_YN = rn.ProvideAsFeedback_YN, ReferralID = rn.ReferralID, ReferralNoteID = rn.ReferralNoteID }).ToList();
            return list;
        }

    }
}

//private ReferralStatus getStatusDescriptionByReferralID()
//{
//    ReferralStatus status =
//        (from s in db.ReferralStatus
//         join r in db.Referrals
//         on s.ReferralStatusID equals r.ReferralStatusID
//         where r.ReferralID == ReferralID
//         select new ReferralStatus { ReferralStatusDesc == ReferralStatusDesc  });
//    return status;
//}

//return (from s in db.ReferralStatus
//        select new ReferralStatus { ReferralStatusDesc = s.ReferralStatusDesc, ReferralStatusID = s.ReferralStatusID }).ToList();
//new List<ReferralStatus> { new ListItem { Text = "", ValueType = ""}