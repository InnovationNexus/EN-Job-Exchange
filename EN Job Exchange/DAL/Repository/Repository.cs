using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENJobExchange.DAL;
using ENJobExchange.Areas.ENPortal.ViewModels;

namespace ENJobExchange.DAL
{
    public partial class Repository
    {
        private Entities db;

        public Repository()
        {
            db = new Entities();
        }


        public IEnumerable<ENJobExchange.Areas.ENPortal.ViewModels.Referral> GetENReferrals(long ENID)
        {
            return (from d in db.Referrals
                    where d.ENID == ENID
                    orderby d.Referral_DT descending, d.ReferralID descending
                    select new ENJobExchange.Areas.ENPortal.ViewModels.Referral 
                    {
                        JobPostingID = d.JobPostingID,
                        ReferralID = d.ReferralID,
                        ReferralTypeID = d.ReferralTypeID,
                        ReferralTypeDescription = d.tblLIST_ReferralType.ReferralTypeName,
                        Referral_DT = d.Referral_DT, 
                        StatusDesc = d.tblLIST_ReferralStatus.ReferralStatusDesc,
                        Account_ENID = d.Account_ENID,
                        ENID = d.ENID, 
                        Name_First = d.Name_First,
                        Name_Last = d.Name_Last,
                        File_CoverLetter = d.File_CoverLetter,
                        File_Resume = d.File_Resume,
                        EN_Notes = d.EN_Notes,
                        EN_Name = d.tblEN.Name,
                        EmployerName = d.tblJobPosting.tblPartner.CompanyName,
                        JobTitle = d.tblJobPosting.JobTitle
                    }).Take(10); 
        }


        public IEnumerable<ENJobExchange.Areas.ENPortal.ViewModels.Referral> GetENReferrals(long ENID, short referralStatusID, short createdLastXDays)
        {
            //--- TODO:  Need to implement date criteria.  Could not figure out how to get LINQ to Entity to recognize the date comparison...
            DateTime dt;
            dt = DateTime.Now.AddDays(-(createdLastXDays));
            if (referralStatusID == -1)
            {
                return (from d in db.Referrals
                        where d.ENID == ENID
                        orderby d.Referral_DT descending, d.ReferralID descending
                        select new ENJobExchange.Areas.ENPortal.ViewModels.Referral
                        {
                            JobPostingID = d.JobPostingID,
                            ReferralID = d.ReferralID,
                            ReferralTypeID = d.ReferralTypeID,
                            ReferralTypeDescription = d.tblLIST_ReferralType.ReferralTypeName,
                            Referral_DT = d.Referral_DT,
                            StatusDesc = d.tblLIST_ReferralStatus.ReferralStatusDesc,
                            Account_ENID = d.Account_ENID,
                            ENID = d.ENID,
                            Name_First = d.Name_First,
                            Name_Last = d.Name_Last,
                            File_CoverLetter = d.File_CoverLetter,
                            File_Resume = d.File_Resume,
                            EN_Notes = d.EN_Notes,
                            EN_Name = d.tblEN.Name,
                            EmployerName = d.tblJobPosting.tblPartner.CompanyName,
                            JobTitle = d.tblJobPosting.JobTitle
                        });
            }
            else if (referralStatusID == 100)
            {
                return (from d in db.Referrals
                        where d.ENID == ENID && d.ReferralStatusID != 2
                        orderby d.Referral_DT descending, d.ReferralID descending
                        select new ENJobExchange.Areas.ENPortal.ViewModels.Referral
                        {
                            JobPostingID = d.JobPostingID,
                            ReferralID = d.ReferralID,
                            ReferralTypeID = d.ReferralTypeID,
                            ReferralTypeDescription = d.tblLIST_ReferralType.ReferralTypeName,
                            Referral_DT = d.Referral_DT,
                            StatusDesc = d.tblLIST_ReferralStatus.ReferralStatusDesc,
                            Account_ENID = d.Account_ENID,
                            ENID = d.ENID,
                            Name_First = d.Name_First,
                            Name_Last = d.Name_Last,
                            File_CoverLetter = d.File_CoverLetter,
                            File_Resume = d.File_Resume,
                            EN_Notes = d.EN_Notes,
                            EN_Name = d.tblEN.Name,
                            EmployerName = d.tblJobPosting.tblPartner.CompanyName,
                            JobTitle = d.tblJobPosting.JobTitle
                        });
            }
            else
            {
                return (from d in db.Referrals
                        where d.ENID == ENID && d.ReferralStatusID == referralStatusID
                        orderby d.Referral_DT descending, d.ReferralID descending
                        select new ENJobExchange.Areas.ENPortal.ViewModels.Referral
                        {
                            JobPostingID = d.JobPostingID,
                            ReferralID = d.ReferralID,
                            ReferralTypeID = d.ReferralTypeID,
                            ReferralTypeDescription = d.tblLIST_ReferralType.ReferralTypeName,
                            Referral_DT = d.Referral_DT,
                            StatusDesc = d.tblLIST_ReferralStatus.ReferralStatusDesc,
                            Account_ENID = d.Account_ENID,
                            ENID = d.ENID,
                            Name_First = d.Name_First,
                            Name_Last = d.Name_Last,
                            File_CoverLetter = d.File_CoverLetter,
                            File_Resume = d.File_Resume,
                            EN_Notes = d.EN_Notes,
                            EN_Name = d.tblEN.Name,
                            EmployerName = d.tblJobPosting.tblPartner.CompanyName,
                            JobTitle = d.tblJobPosting.JobTitle
                        });
            }
        }

        public IEnumerable<ENJobExchange.DAL.ReferralNote> GetENReferralNotes(long ENID)
        {
            return from d in db.ReferralNotes
                   where d.ReferralID == d.tblReferral.ReferralID
                   && d.tblReferral.ENID == ENID
                   select d;
        }

        public DateTime GetReferralDate(long ReferralID)
        {
            var dte = (from m in db.Referrals
                       where m.ReferralID == ReferralID
                       select m.Referral_DT).SingleOrDefault();
            return dte;
        }

        public ENJobExchange.Areas.ENPortal.ViewModels.Referral GetReferralByID(long ReferralID)
        {
            return (from m in db.Referrals
                    where m.ReferralID == ReferralID
                    select new ENJobExchange.Areas.ENPortal.ViewModels.Referral 
                    {
                         ReferralID = m.ReferralID,
                         JobPostingID = m.JobPostingID,
                         ENID = m.ENID,
                         EN_Name = m.tblEN.Name,
                         EmploymentNetworkName = m.tblEN.Name,
                         EmployerName = m.tblJobPosting.tblPartner.CompanyName,
                         EmpID = m.tblJobPosting.tblPartner.PartnerID,
                         Account_ENID = m.Account_ENID,
                         ReferralTypeID = m.ReferralTypeID,
                         ReferralTypeDescription = m.tblLIST_ReferralType.ReferralTypeName,
                         Referral_DT = m.Referral_DT,
                         ReferralStatusID = m.ReferralStatusID,
                         StatusDesc = m.tblLIST_ReferralStatus.ReferralStatusDesc,
                         Name_First = m.Name_First,
                         Name_Last = m.Name_Last,
                         EN_Notes = m.EN_Notes,
                         File_CoverLetter = m.File_CoverLetter,
                         File_Resume = m.File_Resume
                    }).SingleOrDefault(); 
        }


        public IEnumerable<Account_EN> GetENAcctsByID(long ENAcctID)
        {
            return (from m in db.Account_EN
                    where m.ENID == ENAcctID
                    select m).ToList();
        }


        public Account_EN GetENAcctsByUser(long UserAcctID)
        {
            return (from m in db.Account_EN
                    where m.Account_ENID == UserAcctID
                    select m).SingleOrDefault();
        }


        public IEnumerable<JobDisplayModel> JobSearch(string keyword, string zipcode1, int range, long industryTypeID)
        {

            //// **** Testing
            //range = 60;
            //keyword = "man";
            //zipcode1 = "29541";
            //industryType = 0;

            return db.prcSearchJobPostings(zipcode1, range, keyword, industryTypeID).Select(p => new JobDisplayModel
            {
                JobPostingID = p.JobPostingID,
                CompanyName = p.CompanyName,
                PostingStartDate = p.PostingStartDate,
                PostingEndDate = p.PostingEndDate,
                WorkSchedule = p.WorkSchedule,
                EstHoursPerWeek = p.EstHoursPerWeek,
                JobTitle = p.JobTitle,
                CityStateZip = p.City + ", " + p.State
            });
        }


        public IEnumerable<JobDisplayModel> JobSearch(string keyword, string zipcode1, int range, string industryCategoryCode)
        {

            //// **** Testing
            //range = 60;
            //keyword = "man";
            //zipcode1 = "29541";
            //industryType = 0;

            return db.prcSearchJobPostings_WithIndustryCategoryCode(zipcode1, range, keyword, industryCategoryCode).Select(p => new JobDisplayModel
            {
                JobPostingID = p.JobPostingID,
                CompanyName = p.CompanyName,
                PostingStartDate = p.PostingStartDate,
                PostingEndDate = p.PostingEndDate,
                WorkSchedule = p.WorkSchedule,
                EstHoursPerWeek = p.EstHoursPerWeek,
                JobTitle = p.JobTitle,
                CityStateZip = p.City + ", " + p.State
            });
        }

        public string GetEmployerName_ForPartnerID(Int64 partnerID)
        {
            return (from m in db.Partners
                    where m.PartnerID == partnerID 
                    select m.CompanyName).SingleOrDefault();
        }

        public string GetJobZipCode(Int64 JobPostingID)
        {
            Int64? ll = (from m in db.JobPostings
                         where m.JobPostingID == JobPostingID
                         select m.LocationID).SingleOrDefault();

            string zz = (from m in db.Locations
                         where m.LocationID == ll
                         select m.Zip).SingleOrDefault();
            return (zz);
        }

        public string GetCityStateZip_ForJobPostingID(Int64 JobPostingID)
        {
            Int64? ll = (from m in db.JobPostings
                         where m.JobPostingID == JobPostingID
                         select m.LocationID).SingleOrDefault();
            
            string cc = (from m in db.Locations
                    where m.LocationID == ll
                    select m.City).SingleOrDefault();
            string ss = (from m in db.Locations
                         where m.LocationID == ll
                         select m.State).SingleOrDefault();
            string zz = (from m in db.Locations
                         where m.LocationID == ll
                         select m.Zip).SingleOrDefault();
            return (cc + ", " + ss + " " + zz);
        }


        public IEnumerable<Industry_Category> GetIndustryCategories()
        {
            return (from m in db.Industry_Category
                    select m).ToList();
        }


        public IEnumerable<ReferralType> GetReferralTypes()
       {
            return (from m in db.ReferralTypes
                    select m).ToList();
        }



    
    }
}