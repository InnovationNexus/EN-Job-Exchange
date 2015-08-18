using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENJobExchange.Areas.PartnerPortal.Models;
using System.Web.Mvc;

namespace ENJobExchange.Areas.PartnerPortal.ViewModels
{
    public class HomeIndexViewModel
    {
        private ENJobExchange.DAL.Entities db = new ENJobExchange.DAL.Entities();

        public long PartnerID { get; set; }
        public IQueryable<Referral> referrals { get; set; }
        public IEnumerable<Referral> EReferrals { get; set; }
        public IQueryable<JobPosting> jobPostings { get; set; }
        public IEnumerable<JobPosting> EJobPostings { get; set; }
        public IQueryable<HomeIndexViewModel> test { get; set; }
        public string SearchString { get; set; }
        public string jobTitle { get; set; }
        public string partReqNumber { get; set; }
        public int SelectedStatusID { get; set; }
        public SelectList StatusList { get; set; }

        public HomeIndexViewModel()
        {
            this.SelectedStatusID = 0;
            PopulateStatusList();
        }

        public HomeIndexViewModel(long partnerID)
        {
            PartnerID = partnerID;
            this.SelectedStatusID = 0;
            referrals = getFiveReferralsByPartnerID();
            EReferrals = getAllReferralsByPartnerID();
            jobPostings = getFiveJobPostingsByPartnerID();
            EJobPostings = getAllJobPostingsByPartnerID();
            PopulateStatusList();
        }
        
        public HomeIndexViewModel(long partnerID, string searchString, int selectedStatusID)
        {
            SearchString = searchString;
            PartnerID = partnerID;
            this.SelectedStatusID = selectedStatusID;
            PopulateStatusList();

            if (!(string.IsNullOrEmpty(searchString)) || (selectedStatusID != 0))
            {
                if (selectedStatusID == 0)
                {
                    referrals = getFiveReferralsBySearchCriteriaAndPartnerID();
                    EReferrals = getAllReferralsBySearchCriteriaAndPartnerID();
                }
                else
                {
                    referrals = getFiveReferralsBySearchCriteriaAndStatusAndPartnerID();
                    EReferrals = getAllReferralsBySearchCriteriaAndStatusAndPartnerID();
                }

                jobPostings = getFiveJobPostingsByPartnerID();
                EJobPostings = getAllJobPostingsByPartnerID();
            }
            else
            {
                referrals = getFiveReferralsByPartnerID();
                EReferrals = getAllReferralsByPartnerID();
                jobPostings = getFiveJobPostingsByPartnerID();
                EJobPostings = getAllJobPostingsByPartnerID();
            }
        }
        //Populates List of distinct status
        private void PopulateStatusList()
        {
            SelectListItem listItem1 = new SelectListItem() { Text = "[Any]", Value = "0" };
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(listItem1);
            listItems.AddRange(
                (from s in db.ReferralStatus
                 from r in db.Referrals
                 where (s.ReferralStatusID == r.ReferralStatusID)
                 orderby s.ReferralStatusID
                 select s).Distinct().AsEnumerable().Select(x => new SelectListItem() { Text = x.ReferralStatusDesc, Value = x.ReferralStatusID.ToString() })
                 );
            StatusList = new SelectList(listItems, "Value", "Text", this.SelectedStatusID);
        }
        //Returns Five Referrals by and partnerID
        private IQueryable<Referral> getFiveReferralsByPartnerID()
        {
            IQueryable<Referral> list =
                (from r in db.Referrals
                 where r.ENID == PartnerID
                 orderby r.Referral_DT descending, r.ReferralID descending
                 select new Referral { ReferralID = r.ReferralID, ENID = r.ENID, EmployerName = r.tblJobPosting.tblPartner.CompanyName, EmploymentNetworkName = r.tblEN.Name, StatusDesc = r.tblLIST_ReferralStatus.ReferralStatusDesc, ReferralDate = r.Referral_DT, Name_First = r.Name_First, Name_Last = r.Name_Last, JobTitle = r.tblJobPosting.JobTitle, PartnerRequisitionNumber = r.tblJobPosting.PartnerRequisitionNumber }).Take(5);
            return list;
        }
        //Returns Five Referrals by search critearia and partnerID
        private IQueryable<Referral> getFiveReferralsBySearchCriteriaAndPartnerID()
        {
            IQueryable<Referral> list =
                (from r in db.Referrals
                 where (r.ENID == PartnerID && (((r.tblJobPosting.JobTitle.Contains(SearchString)) || (r.Name_First.Contains(SearchString)) || (r.Name_Last.Contains(SearchString)) || (r.tblJobPosting.PartnerRequisitionNumber.Contains(SearchString)))))
                 select new Referral { ReferralID = r.ReferralID, ENID = r.ENID, EmployerName = r.tblJobPosting.tblPartner.CompanyName, EmploymentNetworkName = r.tblEN.Name, StatusDesc = r.tblLIST_ReferralStatus.ReferralStatusDesc, ReferralDate = r.Referral_DT, Name_First = r.Name_First, Name_Last = r.Name_Last, JobTitle = r.tblJobPosting.JobTitle, PartnerRequisitionNumber = r.tblJobPosting.PartnerRequisitionNumber }).Take(5);
            return list;
        }
        //Returns Five Referrals by search critearia, status, and partnerID
        private IQueryable<Referral> getFiveReferralsBySearchCriteriaAndStatusAndPartnerID()
        {
            IQueryable<Referral> list =
                (from r in db.Referrals
                 where ((r.ENID == PartnerID && r.ReferralStatusID == SelectedStatusID) && (((r.tblJobPosting.JobTitle.Contains(SearchString)) || (r.Name_First.Contains(SearchString)) || (r.Name_Last.Contains(SearchString)) || (r.tblJobPosting.PartnerRequisitionNumber.Contains(SearchString)))))
                 select new Referral { ReferralID = r.ReferralID, ENID = r.ENID, EmployerName = r.tblJobPosting.tblPartner.CompanyName, EmploymentNetworkName = r.tblEN.Name, StatusDesc = r.tblLIST_ReferralStatus.ReferralStatusDesc, ReferralDate = r.Referral_DT, Name_First = r.Name_First, Name_Last = r.Name_Last, JobTitle = r.tblJobPosting.JobTitle, PartnerRequisitionNumber = r.tblJobPosting.PartnerRequisitionNumber }).Take(5);
            return list;
        }
        //Returns All Referrals by and partnerID
        private IEnumerable<Referral> getAllReferralsByPartnerID()
        {
            IEnumerable<Referral> list =
                (from r in db.Referrals
                 where r.ENID == PartnerID
                 orderby r.Referral_DT descending, r.ReferralID descending
                 select new Referral { ReferralID = r.ReferralID, ENID = r.ENID, EmployerName = r.tblJobPosting.tblPartner.CompanyName, EmploymentNetworkName = r.tblEN.Name, StatusDesc = r.tblLIST_ReferralStatus.ReferralStatusDesc, ReferralDate = r.Referral_DT, Name_First = r.Name_First, Name_Last = r.Name_Last, JobTitle = r.tblJobPosting.JobTitle, PartnerRequisitionNumber = r.tblJobPosting.PartnerRequisitionNumber }).ToList();
            return list;
        }
        //Returns All Referrals by search critearia and partnerID
        private IEnumerable<Referral> getAllReferralsBySearchCriteriaAndPartnerID()
        {
            IEnumerable<Referral> list =
                (from r in db.Referrals
                 where (r.ENID == PartnerID && ((r.tblJobPosting.JobTitle.Contains(SearchString)) || (r.Name_First.Contains(SearchString)) || (r.Name_Last.Contains(SearchString)) || (r.tblJobPosting.PartnerRequisitionNumber.Contains(SearchString))))
                 select new Referral { ReferralID = r.ReferralID, ENID = r.ENID, EmployerName = r.tblJobPosting.tblPartner.CompanyName, EmploymentNetworkName = r.tblEN.Name, StatusDesc = r.tblLIST_ReferralStatus.ReferralStatusDesc, ReferralDate = r.Referral_DT, Name_First = r.Name_First, Name_Last = r.Name_Last, JobTitle = r.tblJobPosting.JobTitle, PartnerRequisitionNumber = r.tblJobPosting.PartnerRequisitionNumber }).ToList();
            return list;
        }
        //Returns All Referrals by search critearia, status, and partnerID
        private IEnumerable<Referral> getAllReferralsBySearchCriteriaAndStatusAndPartnerID()
        {
            IEnumerable<Referral> list =
                (from r in db.Referrals
                 where ((r.ENID == PartnerID && r.ReferralStatusID == SelectedStatusID) && (((r.tblJobPosting.JobTitle.Contains(SearchString)) || (r.Name_First.Contains(SearchString)) || (r.Name_Last.Contains(SearchString)) || (r.tblJobPosting.PartnerRequisitionNumber.Contains(SearchString)))))
                 select new Referral { ReferralID = r.ReferralID, ENID = r.ENID, EmployerName = r.tblJobPosting.tblPartner.CompanyName, EmploymentNetworkName = r.tblEN.Name, StatusDesc = r.tblLIST_ReferralStatus.ReferralStatusDesc, ReferralDate = r.Referral_DT, Name_First = r.Name_First, Name_Last = r.Name_Last, JobTitle = r.tblJobPosting.JobTitle, PartnerRequisitionNumber = r.tblJobPosting.PartnerRequisitionNumber }).ToList();
            return list;
        }
        //Returns Five Job Postings by Partner ID
        private IQueryable<JobPosting> getFiveJobPostingsByPartnerID()
        {
            IQueryable<JobPosting> eJP =
                (from d in db.JobPostings
                 where d.PartnerID == PartnerID
                 orderby d.CreatedDT descending, d.JobPostingID descending
                 select new JobPosting { PartnerID = d.PartnerID, Active_YN = d.Active_YN, ContactID = d.ContactID, CreatedDT = d.CreatedDT, BusinessCategory = d.BusinessCategory, Description_JobPosting = d.Description_JobPosting, JobPostingID = d.JobPostingID, JobTitle = d.JobTitle, LocationID = d.LocationID, PositionID = d.PositionID, EstHoursPerWeek = d.EstHoursPerWeek, PartnerJobLevel = d.PartnerJobLevel, PartnerRequisitionNumber = d.PartnerRequisitionNumber, PostingEndDate = d.PostingEndDate, PostingStartDate = d.PostingStartDate, Requirements = d.Requirements, WorkSchedule = d.WorkSchedule }).Take(5);
            return eJP;
        }
        //Returns All Job Postings by Partner ID
        private IEnumerable<JobPosting> getAllJobPostingsByPartnerID()
        {
            IEnumerable<JobPosting> eJP =
                (from d in db.JobPostings
                 where d.PartnerID == PartnerID
                 orderby d.CreatedDT descending, d.JobPostingID descending
                 select new JobPosting { PartnerID = d.PartnerID, Active_YN = d.Active_YN, ContactID = d.ContactID, CreatedDT = d.CreatedDT, BusinessCategory = d.BusinessCategory, Description_JobPosting = d.Description_JobPosting, JobPostingID = d.JobPostingID, JobTitle = d.JobTitle, LocationID = d.LocationID, PositionID = d.PositionID, EstHoursPerWeek = d.EstHoursPerWeek, PartnerJobLevel = d.PartnerJobLevel, PartnerRequisitionNumber = d.PartnerRequisitionNumber, PostingEndDate = d.PostingEndDate, PostingStartDate = d.PostingStartDate, Requirements = d.Requirements, WorkSchedule = d.WorkSchedule }).ToList();
            return eJP;
        }
    }
}