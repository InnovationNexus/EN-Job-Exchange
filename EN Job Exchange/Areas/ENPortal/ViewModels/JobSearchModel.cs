using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENJobExchange.DAL;
using System.Data.Entity;


namespace ENJobExchange.Areas.ENPortal.ViewModels
{
    public class JobSearchModel
    {
        private Entities db = new Entities();

        #region "Properties"

        private readonly Repository _rep = new Repository();
        public IEnumerable<JobDisplayModel> PostedJobs { get; set; }
        public SelectList IndustryList { get; set; }
        public SelectList IndustryCategoryList { get; set; }
        public string keyword { get; set; }
        public string zipcode1 { get; set; }
        public int range { get; set; }
        public int industryType { get; set; }
        public string IndustryCategoryCode { get; set; }

        #endregion

        #region "Constructors"

        public JobSearchModel()
        {
            this.industryType = 0;
            this.range = 20;
            PopulateIndustryList();
            PopulateIndustryCategoryList();
        }

        public JobSearchModel(string keyword, string zipcode1, int range, int SelectedIndustryID)
        {
            this.keyword = keyword;
            this.zipcode1 = zipcode1;
            this.range = range;
            this.industryType = SelectedIndustryID;
            this.IndustryCategoryCode = "";
            GetMatchingResults();
            PopulateIndustryList();
            PopulateIndustryCategoryList();
        }

        public JobSearchModel(string keyword, string zipcode1, int range, string SelectedIndustryCategoryCode)
        {
            this.keyword = keyword;
            this.zipcode1 = zipcode1;
            this.range = range;
            this.industryType = 0;
            this.IndustryCategoryCode = SelectedIndustryCategoryCode;
            GetMatchingResults();
            PopulateIndustryList();
            PopulateIndustryCategoryList();
        }

        #endregion


        public void GetMatchingResults()
        {
            if (this.industryType == 0)
            {
                //--- Search by general Industry Category Code if specific Industry was not specified.
                //--- Search will ignore the Category Code parameter/cirteria if it is not specified.
                this.PostedJobs = _rep.JobSearch(this.keyword, this.zipcode1, this.range, this.IndustryCategoryCode);
            }
            else
            {
                //--- Search will ignore the Industry Type ID parameter/cirteria if it is not specified.
                this.PostedJobs = _rep.JobSearch(this.keyword, this.zipcode1, this.range, this.industryType);
            }
        }

        private void PopulateIndustryList()
        {
            SelectListItem itm1 = new SelectListItem() { Text = "[Any]", Value = "0" };
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(itm1);
            items.AddRange(
                    (from i in db.Industries
                     from l in db.LINK_Partner_to_Industry
                     from p in db.Partners
                     where (i.IndustryID == l.IndustryID) && (l.PartnerID == p.PartnerID)
                     orderby i.Industry_Title
                     select i).Distinct().AsEnumerable().Select(r => new SelectListItem() { Text = String.Concat(r.Industry_Title.ToString().Substring(0, Math.Min(r.Industry_Title.Length, 50)), r.Industry_Title.Length <= 50 ? "" : "..."), Value = r.IndustryID.ToString() })
                     );
            this.IndustryList = new SelectList(items, "Value", "Text", this.industryType);
        }

        private void PopulateIndustryCategoryList()
        {
            SelectListItem itm1 = new SelectListItem() { Text = "[Any]", Value = "" };
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(itm1);
            items.AddRange(
                    (from i in db.Industries
                     from l in db.LINK_Partner_to_Industry
                     from p in db.Partners
                     from c in db.Industry_Category
                     where (i.IndustryID == l.IndustryID) && (l.PartnerID == p.PartnerID) && (i.NAIC_Industry_Code == c.NAIC_Industry_Code)
                     /*orderby i.Industry_Title*/
                     group c by c.Category_Title into g
                     select new { Category_Title = g.Key, Category_Code = g.Min(c => c.NAIC_Industry_Code) }).Distinct().AsEnumerable().Select(r => new SelectListItem() { Text = String.Concat(r.Category_Title.ToString().Substring(0, Math.Min(r.Category_Title.Length, 50)), r.Category_Title.Length <= 50 ? "" : "..."), Value = r.Category_Code.ToString() })
                     );
            this.IndustryCategoryList = new SelectList(items, "Value", "Text", this.IndustryCategoryCode);
        }
    
    }
}