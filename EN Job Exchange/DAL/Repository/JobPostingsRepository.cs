using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENJobExchange.Areas.PartnerPortal.Models;
using ENJobExchange.Areas.ENPortal.ViewModels;

namespace ENJobExchange.DAL
{
    public partial class Repository 
    {

        public IEnumerable<DAL.JobPosting> GetJobPostings()
        {
            return (from d in db.JobPostings
                    select d).ToList();
        }


        public JobPosting getOneJobPosting(long jobPostingID)
        {
            using (Entities db = new Entities())
            {
                JobPosting eJP =
                    (from d in db.JobPostings
                     where d.JobPostingID == jobPostingID
                     select new JobPosting { PartnerID = d.PartnerID, Active_YN = d.Active_YN, ContactID = d.ContactID, CreatedDT = d.CreatedDT, BusinessCategory = d.BusinessCategory, Description_JobPosting = d.Description_JobPosting, JobPostingID = d.JobPostingID, JobTitle = d.JobTitle, LocationID = d.LocationID, PositionID = d.PositionID, EstHoursPerWeek = d.EstHoursPerWeek, PartnerJobLevel = d.PartnerJobLevel, PartnerRequisitionNumber = d.PartnerRequisitionNumber, PostingEndDate = d.PostingEndDate, PostingStartDate = d.PostingStartDate, Requirements = d.Requirements, WorkSchedule = d.WorkSchedule }).SingleOrDefault();
                return eJP;
            }
        }



        public JobPosting getJobPostingByID(long jobPostingID)
        {
            using (Entities db = new Entities())
            {
                JobPosting eJP =
                    (from d in db.JobPostings
                     where d.JobPostingID == jobPostingID
                     select d).SingleOrDefault();
                     //                     select new JobPosting { PartnerID = d.PartnerID, Active_YN = d.Active_YN, ContactID = d.ContactID, CreatedDT = d.CreatedDT, BusinessCategory = d.BusinessCategory, Description_JobPosting = d.Description_JobPosting, JobPostingID = d.JobPostingID, JobTitle = d.JobTitle, LocationID = d.LocationID, PositionID = d.PositionID, EstHoursPerWeek = d.EstHoursPerWeek, PartnerJobLevel = d.PartnerJobLevel, PartnerRequisitionNumber = d.PartnerRequisitionNumber, PostingEndDate = d.PostingEndDate, PostingStartDate = d.PostingStartDate, Requirements = d.Requirements, WorkSchedule = d.WorkSchedule }).SingleOrDefault();
                return eJP;
            }
        }

        public JobDisplayModel getJobDisplayByID(long jobPostingID)
        {
            using (Entities db = new Entities())
            {
                JobDisplayModel jdm =
                    (from d in db.JobPostings
                     where d.JobPostingID == jobPostingID
                     select new JobDisplayModel { Active_YN = d.Active_YN, CreatedDT = d.CreatedDT, BusinessCategory = d.BusinessCategory, Description_JobPosting = d.Description_JobPosting, JobPostingID = d.JobPostingID, JobTitle = d.JobTitle, EstHoursPerWeek = d.EstHoursPerWeek, PostingEndDate = d.PostingEndDate, PostingStartDate = d.PostingStartDate, Requirements = d.Requirements, WorkSchedule = d.WorkSchedule }).SingleOrDefault();
                return jdm;
            }
        }
    
    
    
    
    }
}