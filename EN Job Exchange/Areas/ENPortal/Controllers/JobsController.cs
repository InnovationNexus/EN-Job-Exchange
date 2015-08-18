using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENJobExchange.DAL;
using ENJobExchange.Areas.ENPortal.ViewModels;

namespace ENJobExchange.Areas.ENPortal.Controllers
{
    public class JobsController : Controller
    {
        Entities db = new Entities();
        private Repository _rep = new Repository();

        [HttpGet]
        public ActionResult Index()
        {
            JobSearchModel model = new JobSearchModel();
            return View(model);
        }

        /*
        [HttpPost]
        //--- Used if searching by SPECIFIC Industry Code
        public ActionResult Index([Bind(Include = "keyword, zipcode1, Range, industryType")]string keyword, string zipcode1, int Range, int industryType)
        {
            JobSearchModel model = new JobSearchModel(keyword, zipcode1, Range, industryType);
            return View(model);
        }
        */

        [HttpPost]
        //--- Used if searching by GENERAL Industry Category
        public ActionResult Index([Bind(Include="keyword, zipcode1, Range, industryCategoryCode")]string keyword, string zipcode1, int Range, string industryCategoryCode)
        {
            JobSearchModel model = new JobSearchModel(keyword, zipcode1, Range, industryCategoryCode);
            return View(model);
        }


        public ActionResult Details(long id)
        {
            //ViewBag.Account = _rep.getENIDbyJobPostingID(id);
            JobDisplayModel model = new JobDisplayModel(id);
            return View(model);
        }

        
        
        public ActionResult MakeReferral(long id)
        {
           var model = new JobDisplayModel(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult CreateReferral()
        {
            var model = new ENJobExchange.Areas.ENPortal.ViewModels.Referral() { };
            return View(model);
        }


        //[HttpPost]
        //public ActionResult CreateReferral(FormCollection form)
        //{
        //    var model = new ENJobExchange.Areas.ENPortal.ViewModels.Referral() { };
        //    return View(model);
        //}


  














    }
}
