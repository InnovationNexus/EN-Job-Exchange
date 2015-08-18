using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ENJobExchange.Areas.PartnerPortal.Models;

namespace ENJobExchange.Areas.PartnerPortal.ViewModels
{
    public class JobPostingViewModel
    {

        public long JobPostingID { get; set; }
        public JobPosting jobPosting { get; set; }
        public ENJobExchange.DAL.Entities db;

        public JobPostingViewModel()
        {
            db = new ENJobExchange.DAL.Entities();
        }

        public JobPostingViewModel(long jobPostingID)
        {
            db = new ENJobExchange.DAL.Entities();
            JobPostingID = jobPostingID;
            jobPosting = getOneJobPostingsByJobPostingID();
        }

        private JobPosting getOneJobPostingsByJobPostingID()
        {
            JobPosting eJP =
                (from d in db.JobPostings
                 where d.JobPostingID == JobPostingID
                 select new JobPosting { PartnerID = d.PartnerID, Active_YN = d.Active_YN, ContactID = d.ContactID, CreatedDT = d.CreatedDT, BusinessCategory = d.BusinessCategory, Description_JobPosting = d.Description_JobPosting, JobPostingID = d.JobPostingID, JobTitle = d.JobTitle, LocationID = d.LocationID, PositionID = d.PositionID, EstHoursPerWeek = d.EstHoursPerWeek, PartnerJobLevel = d.PartnerJobLevel, PartnerRequisitionNumber = d.PartnerRequisitionNumber, PostingEndDate = d.PostingEndDate, PostingStartDate = d.PostingStartDate, Requirements = d.Requirements, WorkSchedule = d.WorkSchedule }).Single();
            return eJP;
        }

        public void EditReferral(ENJobExchange.Areas.PartnerPortal.ViewModels.JobPostingViewModel model)
        {
            ENJobExchange.DAL.JobPosting dataJobPosting = db.JobPostings.Where(x => x.JobPostingID == JobPostingID).Single();

            dataJobPosting.Active_YN = this.jobPosting.Active_YN;
            //dataJobPosting.BusinessCategory = model.jobPosting.BusinessCategory;
            dataJobPosting.ContactID = model.jobPosting.ContactID;
            dataJobPosting.CreatedDT = model.jobPosting.CreatedDT;
            dataJobPosting.Description_External = model.jobPosting.Description_External;
            dataJobPosting.Description_JobPosting = model.jobPosting.Description_JobPosting;
            dataJobPosting.EstHoursPerWeek = model.jobPosting.EstHoursPerWeek;
            //dataJobPosting.JobPostingID = model.jobPosting.JobPostingID;
            dataJobPosting.JobTitle = model.jobPosting.JobTitle;
            dataJobPosting.LocationID = model.jobPosting.LocationID;
            //dataJobPosting.PartnerID = model.jobPosting.PartnerID;
            dataJobPosting.PartnerJobLevel = model.jobPosting.PartnerJobLevel;
            dataJobPosting.PartnerRequisitionNumber = model.jobPosting.PartnerRequisitionNumber;
            //dataJobPosting.PositionID = model.jobPosting.PositionID;
            dataJobPosting.PostingStartDate = model.jobPosting.PostingStartDate;
            dataJobPosting.PostingEndDate = model.jobPosting.PostingEndDate;
            //dataJobPosting.Requirements = model.jobPosting.Requirements;
            //dataJobPosting.WorkSchedule = model.jobPosting.WorkSchedule;

            db.Entry(dataJobPosting).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        
    }
}